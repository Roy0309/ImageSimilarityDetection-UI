using System;
using System.Threading.Tasks;

namespace SimilarImages
{
    internal static class MatrixHelper
    {
        public static double[,] GetTansposedMatrix(double[,] matrix)
        {
            int row = matrix.GetUpperBound(0) + 1;
            int column = matrix.GetUpperBound(1) + 1;
            double[,] newMatrix = new double[column, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    newMatrix[j, i] = matrix[i, j];
                }
            }
            return newMatrix;
        }

        public static double[,] MultiplyMatrixes(double[,] matrixA, double[,] matrixB)
        {
            int aRows = matrixA.GetUpperBound(0) + 1;
            int aCols = matrixA.GetUpperBound(1) + 1;
            int bRows = matrixB.GetUpperBound(0) + 1;
            int bCols = matrixB.GetUpperBound(1) + 1;
            if (aCols != bRows)
            { throw new Exception("Non-conformable matrices in MatrixProduct"); }

            double[,] result = new double[aRows, bCols];
            Parallel.For(0, aRows, i =>
            {
                for (int j = 0; j < bCols; ++j)
                    for (int k = 0; k < aCols; ++k)
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
            });
            return result;
        }

    }
}
