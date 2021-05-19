using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rowLength = size[0];
            int colLength = size[1];

            int[,] matrix = new int[rowLength, colLength];

            //fill matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int largestSquareSum= int.MinValue;

            int squareTopLeft = 0;
            int squareTopRight = 0;
            int squareBottomLeft = 0;
            int squareBottomRight = 0;

            //read matrix
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSquare
                        =
                        matrix[row, col] 
                        + 
                        matrix[row, col + 1]
                        +
                        matrix[row + 1, col]
                        + 
                        matrix[row + 1, col + 1];

                    if (currentSquare > largestSquareSum)
                    {
                        largestSquareSum = currentSquare;
                        squareTopLeft = matrix[row, col];
                        squareTopRight = matrix[row, col + 1];
                        squareBottomLeft = matrix[row + 1, col];
                        squareBottomRight = matrix[row + 1, col + 1];
                    }
                }
            }
            Console.WriteLine($"{squareTopLeft} {squareTopRight}");
            Console.WriteLine($"{squareBottomLeft} {squareBottomRight}");
            Console.WriteLine(largestSquareSum);
        }
    }
}
