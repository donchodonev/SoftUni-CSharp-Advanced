using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] inputValues = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputValues[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col == row)
                    {
                        primaryDiagonalSum += matrix[row, col];
                        break;
                    }
                }
            }
            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
