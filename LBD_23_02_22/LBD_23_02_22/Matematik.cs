using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBD_23_02_22
{
    class Matematik
    {
        public static double Opr(int n,double[][] a)
        {
            double[,] a2 = new double[n,n];
            for(int i = 0; i < n; ++i)
                for (int o = 0; o < n; ++o) a2[i, o] = Convert.ToDouble(a[i][o]);
            return DetRec(a2);
        }
        private static double DetRec(double[,] matrix)
        {
            if (matrix.Length == 4)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double sign = 1, result = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                double[,] minor = GetMinor(matrix, i);
                result += sign * matrix[0, i] * DetRec(minor);
                sign = -sign;
            }
            return result;
        }

        private static double[,] GetMinor(double[,] matrix, int n)
        {
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0, col = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == n)
                        continue;
                    result[i - 1, col] = matrix[i, j];
                    col++;
                }
            }
            return result;
        }
    }
}
