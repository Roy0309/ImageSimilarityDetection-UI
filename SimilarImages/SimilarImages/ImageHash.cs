using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimilarImages
{
    internal class ImageHash
    {
        private static readonly string[] imageExtensions = new string[] { ".png", ".jpg", ".jpeg" };
        private static int currentPrecision = 20;
        private static InterpolationMode currentInterpolationMode;

        public static List<Tuple<string, string, double>> GetSimilarity(
            string folderPath, out int validImageCount, int precision, 
            InterpolationMode interpolationMode, HashEnum hashEnum, int threshold)
        {
            Stopwatch watch = new Stopwatch();

            if (threshold < 0 || threshold >= 100)
            {
                throw new ArgumentOutOfRangeException("Threshold should be [0,100);");
            }
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException("Directory not found.");
            }
            Debug.WriteLine($"Hash Algorithm: {hashEnum}\nPrecision: {precision}\n" +
                            $"Interpolation Mode: {interpolationMode}\nThreshold: {threshold}%");

            watch.Restart();

            // Set config
            currentPrecision = precision;
            currentInterpolationMode = interpolationMode;

            // Get hashes
            var imageHashPairs = GetImageHashes(folderPath, hashEnum);
            validImageCount = imageHashPairs.Length;
            if (validImageCount < 2) { return null; }

            watch.Stop();
            long hashTime = watch.ElapsedMilliseconds;
            watch.Restart();

            // Compare hashes
            var tuples = new List<Tuple<string, string, double>>();
            Parallel.For(0, imageHashPairs.Length, i =>
            {
                for (int j = imageHashPairs.Length - 1; j > i; j--)
                {
                    double percent = GetHammingDistancePercent(
                        imageHashPairs[i].Value, imageHashPairs[j].Value);
                    if (percent >= (double)threshold / 100)
                    {
                        var tuple = Tuple.Create(imageHashPairs[i].Key,
                            imageHashPairs[j].Key, percent);
                        tuples.Add(tuple);
                    }
                }
            });

            watch.Stop();
            long compareTime = watch.ElapsedMilliseconds;
            Debug.WriteLine($"GetHash: {hashTime}ms; CompareHash: {compareTime}ms");

            // Sort by similarity
            return tuples.OrderByDescending(u => u.Item3).ToList();
        }

        public enum HashEnum
        {
            Difference,
            Mean,
            Perceptual
        }

        private static KeyValuePair<string, string>[] GetImageHashes(string folderPath, HashEnum hashEnum)
        {
            // Get images
            DirectoryInfo di = new DirectoryInfo(folderPath);
            var imageNames = from file in di.GetFiles()
                             where imageExtensions.Contains(file.Extension)
                             select file.Name;
            Debug.WriteLine($"Directory: {folderPath}\nImage count: {imageNames.Count()}");

            // Get hash algorithm
            Func<string, string> hashMethod = null;
            switch (hashEnum)
            {
                case HashEnum.Difference:
                    hashMethod = (imageName) => 
                        GetDifferenceHash(Path.Combine(folderPath, imageName));
                    break;
                case HashEnum.Mean:
                    hashMethod = (imageName) => 
                        GetMeanHash(Path.Combine(folderPath, imageName));
                    break;
                case HashEnum.Perceptual:
                    hashMethod = (imageName) => 
                        GetPerceptualHash(Path.Combine(folderPath, imageName));
                    break;
                default: break;
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Get hashes
            var imageHashPairs = new ConcurrentDictionary<string, string>();
            Parallel.ForEach(imageNames, imageName =>
            {
                string hash = hashMethod(imageName);
                if (!string.IsNullOrEmpty(hash))
                {
                    imageHashPairs.AddOrUpdate(imageName, hash, (k, v) => v = hash);
                }
            });

            watch.Stop();
            Debug.WriteLine($"Valid count: {imageHashPairs.Count} elapsed time: {watch.ElapsedMilliseconds}ms");
            return imageHashPairs.ToArray();
        }

        private static string GetMeanHash(string filename)
        {
            // Get gray image matrix
            double[,] imageMatrix = GetResizedGrayImageMatrix(filename, 
                currentPrecision, currentPrecision, out double grayMean);
            if (imageMatrix == null) { return null; }
            
            // Get hash
            StringBuilder sbHash = new StringBuilder();
            for (int w = 0; w < currentPrecision; w++)
            {
                for (int h = 0; h < currentPrecision; h++)
                {
                    sbHash.Append(imageMatrix[w, h] > grayMean ? "1" : "0");
                }
            }
            return sbHash.ToString();
        }

        private static string GetDifferenceHash(string filename)
        {
            // Get gray image matrix
            double[,] imageMatrix = GetResizedGrayImageMatrix(filename,
                currentPrecision, currentPrecision + 1, out double _);
            if (imageMatrix == null) { return null; }

            // Get hash
            StringBuilder sbHash = new StringBuilder();
            for (int w = 0; w < currentPrecision; w++)
            {
                for (int h = 0; h < currentPrecision; h++)
                {
                    sbHash.Append(imageMatrix[w, h] > imageMatrix[w + 1, h] ? "1" : "0");
                }
            }
            return sbHash.ToString();
        }

        #region Perceptual hash

        private static string GetPerceptualHash(string filename)
        {
            // Get gray image matrix
            double[,] imageMatrix = GetResizedGrayImageMatrix(filename,
                currentPrecision, currentPrecision, out double _);
            if (imageMatrix == null) { return null; }

            // Generate transformation matrix
            double[,] transMatrix = GetTransMatrix(currentPrecision);

            // Get DCT coefficient
            double[,] frequencyMatrix = MatrixHelper.MultiplyMatrixes(
                MatrixHelper.MultiplyMatrixes(transMatrix, imageMatrix),
                MatrixHelper.GetTansposedMatrix(transMatrix));

            // Take low frequency part and get mean frequency
            double frequencySum = 0;
            int height = currentPrecision / 2;
            int width = currentPrecision / 2;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    frequencySum += frequencyMatrix[i, j];
                }
            }
            double frequencyMean = frequencySum / height / width;

            // Get hash
            StringBuilder sbHash = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    sbHash.Append(frequencyMatrix[i, j] > frequencyMean ? "1" : "0");
                }
            }
            return sbHash.ToString();
        }

        private static ConcurrentDictionary<int, double[,]> listTransMatrix = 
            new ConcurrentDictionary<int, double[,]>();

        private static double[,] GetTransMatrix(int precision)
        {
            return listTransMatrix.GetOrAdd(precision, key =>
            {
                // Generate transformation matrix
                double[,] transMatrix = new double[key, key];
                for (int i = 0; i < transMatrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < transMatrix.GetUpperBound(1) + 1; j++)
                    {
                        double ci = i == 0 ? Math.Sqrt(1.0 / key) : Math.Sqrt(2.0 / key);
                        transMatrix[i, j] = ci * Math.Cos(Math.PI * (j + 0.5) * i / key);
                    }
                }
                return transMatrix;
            });
        }

        #endregion Perceptual hash

        private static double[,] GetResizedGrayImageMatrix(string filename,
            int height, int width, out double grayMean)
        {
            grayMean = 0;

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            // Load original image
            Bitmap originalBmp;
            try { originalBmp = new Bitmap(filename); }
            catch (ArgumentException) { return null; }

            watch.Stop();
            long originalBmpTime = watch.ElapsedMilliseconds;
            watch.Restart();
            long resizeImageTime = 0;

            // Resize image
            double[,] imageMatrix = new double[width, height];
            double graySum = 0;
            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CompositingQuality = CompositingQuality.HighSpeed;
                    g.InterpolationMode = currentInterpolationMode;
                    g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.DrawImage(originalBmp, 0, 0, bmp.Width, bmp.Height);
                }

                watch.Stop();
                resizeImageTime = watch.ElapsedMilliseconds;
                watch.Restart();

                // Get gray image matrix
                BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                IntPtr ptr = bd.Scan0;
                int length = Math.Abs(bd.Stride) * bmp.Height;
                byte[] pixels = new byte[length];
                Marshal.Copy(ptr, pixels, 0, length);
                for (int i = 0; i < pixels.Length; i += 4) // BGRA
                {
                    double gray = pixels[i + 2] * 0.30 +
                                  pixels[i + 1] * 0.59 +
                                  pixels[i + 0] * 0.11;
                    int x = Math.DivRem(i / 4, height, out int y);
                    imageMatrix[x, y] = gray;
                    graySum += gray;
                }
                bmp.UnlockBits(bd);
            }

            watch.Stop();
            long imageMatrixTime = watch.ElapsedMilliseconds;
            //Debug.WriteLine($"Original: {originalBmpTime,3}ms; Resize: {resizeImageTime,3}ms; Matrix: {imageMatrixTime}ms");

            originalBmp.Dispose();

            // Get mean gray
            grayMean = graySum / height / width;

            return imageMatrix;
        }

        private static double GetHammingDistancePercent(string hash1, string hash2)
        {
            if (hash1.Length != hash2.Length)
            {
                throw new ArgumentException("Two hashes have different length.");
            }

            int sameNum = 0;
            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] == hash2[i]) { sameNum++; }
            }
            return (double)sameNum / hash1.Length;
        }
    }
}
