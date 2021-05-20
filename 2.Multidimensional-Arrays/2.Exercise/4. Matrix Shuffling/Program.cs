using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizeOfMatrix[0];
            int cols = sizeOfMatrix[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int [] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
               
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputArgs[col];
                }
            }

            string commandArgs = Console.ReadLine();

            while (commandArgs != "END")
            {
                string [] commandArray = commandArgs.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandArray[0] != "swap" || commandArray.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    commandArgs = Console.ReadLine();
                    continue;
                }

                int firstArrayRow = int.Parse(commandArray[1].ToString());
                int firstArrayCol = int.Parse(commandArray[2].ToString());
                int secondArrayRow = int.Parse(commandArray[3].ToString());
                int secondArrayCol = int.Parse(commandArray[4].ToString());

                if (firstArrayRow >= rows || secondArrayRow >= rows || firstArrayCol >= cols || secondArrayCol >= cols)
                {
                    Console.WriteLine("Invalid input!");
                    commandArgs = Console.ReadLine();
                    continue;
                }


                int elementToSwap = matrix[firstArrayRow, firstArrayCol];
                int elementToSwapWith = matrix[secondArrayRow, secondArrayCol];

                matrix[firstArrayRow, firstArrayCol] = elementToSwapWith;
                matrix[secondArrayRow, secondArrayCol] = elementToSwap;


                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row,col]} ");
                    }
                    Console.WriteLine();
                }

                commandArgs = Console.ReadLine();

            }
        }
    }
}
