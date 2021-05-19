using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rowSize = inputArgs[0];
            int colSize = inputArgs[1];

            int[][] jaggedArray = new int[rowSize][];

            //seed jagged array

            for (int row = 0; row < rowSize; row++)
            {
                int[] charArr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = charArr;
            }

            int maxSum = int.MinValue;

            int winningRowIndex = 0;
            int winningColIndex = 0;


            for (int row = 0; row < rowSize - 2; row++)
            {
                for (int col = 0; col < colSize - 2; col++)
                {
                    int sumTop = 0;
                    int sumMid = 0;
                    int sumBottom = 0;


                    for (int i = col; i < col + 3; i++)
                    {
                        sumTop += jaggedArray[row][i];
                    }

                    for (int i = col; i < col + 3; i++)
                    {
                        sumMid += jaggedArray[row + 1][i];
                    }

                    for (int i = col; i < col + 3; i++)
                    {
                        sumBottom += jaggedArray[row + 2][i];
                    }

                    int rectangleSize = sumTop + sumMid + sumBottom;


                    if (rectangleSize > maxSum)
                    {
                        maxSum = rectangleSize;

                        winningRowIndex = row;
                        winningColIndex = col;

                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = winningRowIndex; i < winningRowIndex + 3; i++)
            {
                for (int k = winningColIndex; k < winningColIndex + 3; k++)
                {
                    Console.Write(jaggedArray[i][k] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
