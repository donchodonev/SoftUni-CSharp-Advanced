using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
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

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandArgs = input.Split();

                string command = commandArgs[0];

                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int num = int.Parse(commandArgs[3]);

                if (matrix.GetLength(0) > row && matrix.GetLength(1) > col && row >= 0 && col >= 0)
                {
                    if (command == "Add")
                    {
                        matrix[row, col] += num;
                    }
                    else
                    {
                        matrix[row, col] -= num;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                input = Console.ReadLine();
            }



            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
