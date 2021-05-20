using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            //seed columns
            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            //multiply or divide by 2 depending on length

            for (int row = 0; row < jaggedArray.GetLength(0) - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int i = 0; i < jaggedArray[row].Length; i++)
                    {
                        jaggedArray[row][i] *= 2;
                        jaggedArray[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jaggedArray[row].Length; i++)
                    {
                        jaggedArray[row][i] /= 2;
                    }
                    for (int j = 0; j < jaggedArray[row + 1].Length; j++)
                    {
                        jaggedArray[row + 1][j] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                double value = double.Parse(commandArgs[3]);

                if (row >= 0 && col >= 0 && row < jaggedArray.GetLength(0) && col < jaggedArray[row].Length)
                {
                    if (commandArgs[0] == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else
                    {
                        jaggedArray[row][col] -= value;
                    }
                }

                command = Console.ReadLine();

            }


            foreach (var array in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', array));
            }
        }
    }
}
