using System;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Matrices
{
    public class MatrixOperations
    {
 

        /// <summary>
        /// Basic matrix multiplication with no error handling
        /// </summary>
        public static double[,] MatrixMultiply(double[,] a, double[,] b)
        {
            double[,] c = new double[a.GetLength(0), b.GetLength(1)];

            for (int rowInA = 0; rowInA < a.GetLength(0); rowInA++)
            {
                for (int colInB = 0; colInB < b.GetLength(1); colInB++)
                {
                    double result = 0.0;
                    for (int i = 0; i < a.GetLength(1); i++)
                        result += a[rowInA, i] * b[i, colInB];

                    c[rowInA, colInB] = result;
                }
            }

            return c;
        }
    }
}