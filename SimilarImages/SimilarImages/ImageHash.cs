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
        private static readonly string[] imageExtensions = new string[] { ".png", ".jpg", ".jpeg", ".bmp" };
        private static int currentPrecision;
        private static InterpolationMode currentInterpolationMode;

        public static List<Tuple<string, string, double>> GetSimilarity(
            ref List<string> folderPathes, HashConfig hashConfig, 
            out int validImageCount, out int similarImageCount)
        {
            if (!folderPathes.TrueForAll((path)=>Directory.Exists(path)))
            {
                throw new DirectoryNotFoundException("Directory not found.");
            }

            Debug.WriteLine($"HashConfig: " +
                $"Algorithm({hashConfig.HashMethod}) Precision({hashConfig.Precision}) " +
                $"InterpolationMode({hashConfig.InterpolationMode}) Threshold({hashConfig.Threshold}%)");

            // Set config
            currentPrecision = hashConfig.Precision;
            currentInterpolationMode = hashConfig.InterpolationMode;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Get hashes
            KeyValuePair<string, string>[] imageHashPairs = null;
            foreach (string folderPath in folderPathes)
            {
                var pairs = GetImageHashes(folderPath, hashConfig.HashMethod);
                if (pairs != null)
                {
                    imageHashPairs = imageHashPairs == null ? pairs : 
                        imageHashPairs.Union(pairs).ToArray();
                }
            }
            
            validImageCount = imageHashPairs == null ? 0 : imageHashPairs.Length;
            similarImageCount = 0;
            if (imageHashPairs == null) { return null; }

            watch.Stop();
            long hashTime = watch.ElapsedMilliseconds;
            watch.Restart();

            // Compare hashes
            var similarImagePathes = new ConcurrentDictionary<string, byte>();
            var tuples = new ConcurrentBag<Tuple<string, string, double>>();
            Parallel.For(0, imageHashPairs.Length, i =>
            {
                for (int j = imageHashPairs.Length - 1; j > i; j--)
                {
                    double percent = GetHammingDistancePercent(
                        imageHashPairs[i].Value, imageHashPairs[j].Value);

                    if (percent >= (double)hashConfig.Threshold / 100)
                    {
                        similarImagePathes.TryAdd(imageHashPairs[i].Key, 1);
                        similarImagePathes.TryAdd(imageHashPairs[j].Key, 1);

                        var tuple = Tuple.Create(imageHashPairs[i].Key,
                            imageHashPairs[j].Key, percent);
                        tuples.Add(tuple);
                    }
                }
            });
            similarImageCount = similarImagePathes.Count;

            watch.Stop();
            long compareTime = watch.ElapsedMilliseconds;
            Debug.WriteLine($"GetHash: {hashTime}ms\nCompareHash: {compareTime}ms");
            Debug.WriteLine($"TupleCount: {tuples.Count}\nSimilarImageCount: {similarImageCount}");

            // Sort by similarity
            return tuples.OrderByDescending(u => u.Item3).ToList();
        }

        private static KeyValuePair<string, string>[] GetImageHashes(string folderPath, HashEnum hashEnum)
        {
            // Get images
            DirectoryInfo di = new DirectoryInfo(folderPath);
            var imageNames = from imageName 
                             in Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories)
                             where imageExtensions.Any(imageName.ToLower().EndsWith)
                             select imageName;
            Debug.WriteLine($"Directory: {folderPath}\nImageCount: {imageNames.Count()}");
            if (imageNames.Count() < 2) { return null; }

            // Get hash algorithm
            Func<string, string> hashMethod = null;
            switch (hashEnum)
            {
                case HashEnum.Difference:
                    hashMethod = (imageName) => GetDifferenceHash(imageName);
                    break;
                case HashEnum.Mean:
                    hashMethod = (imageName) => GetMeanHash(imageName);
                    break;
                case HashEnum.Perceptual:
                    hashMethod = (imageName) => GetPerceptualHash(imageName);
                    break;
                default: break;
            }

            // Get hashes
            var imageHashPairs = new ConcurrentDictionary<string, string>();
            Parallel.ForEach(imageNames,
                // TODO: Add performance limitation option 
                //new ParallelOptions { MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling((Environment.ProcessorCount * 0.5) * 1.0)) },
                imageName =>
            {
                string hash = hashMethod(imageName);
                if (!string.IsNullOrEmpty(hash))
                {
                    imageHashPairs.AddOrUpdate(imageName, hash, (k, v) => v = hash);
                }
            });

            Debug.WriteLine($"ImageCount(Valid): {imageHashPairs.Count}");
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

            // Load original image
            Bitmap originalBmp;
            try { originalBmp = new Bitmap(filename); }
            catch (ArgumentException) { return null; }

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

                originalBmp.Dispose();

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
