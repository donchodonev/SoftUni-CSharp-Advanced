using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rowSize = matrixSize[0];
            int colSize = matrixSize[1];

            int maxCapacity = rowSize * colSize;
            int currentCapacity = 0;

            bool isNotFull = currentCapacity != maxCapacity;

            Queue<char> charSequence = new Queue<char>(Console.ReadLine().ToCharArray());

            char[,] matrix = new char[rowSize, colSize];

            int counter = 0;

            while (isNotFull)
            {
                for (int row = 0; row < rowSize && isNotFull; row++)
                {
                    if (counter == 0)
                    {
                        for (int col = 0; col < colSize && isNotFull; col++)
                        {
                            matrix[row, col] = charSequence.Peek();
                            charSequence.Enqueue(charSequence.Dequeue());
                            currentCapacity++;
                            isNotFull = currentCapacity != maxCapacity;
                        }
                        counter++;
                    }
                    else
                    {
                        for (int col = colSize - 1; col >= 0 && isNotFull; col--)
                        {
                            matrix[row, col] = charSequence.Peek();
                            charSequence.Enqueue(charSequence.Dequeue());
                            currentCapacity++;
                            isNotFull = currentCapacity != maxCapacity;
                        }
                        counter = 0;
                    }
                }
            }
            PrintMatrix(matrix);
        }
    }
}
