using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        public static int[,] TriggerBomb (int [,] matrix, int row, int col)
        {
            int[,] currentMatrix = matrix;

            int damage = matrix[row, col];

            if (damage <= 0)
            {
                return currentMatrix;
            }

            Queue<(int dmgRow, int dmgCol)> splashDamage = new Queue<(int, int)>();

            splashDamage.Enqueue((-1, 1));//up and one right
            splashDamage.Enqueue((-1, -1));//up and one left
            splashDamage.Enqueue((1, -1));//down and one left
            splashDamage.Enqueue((1, 1));//down and one right
            splashDamage.Enqueue((-1, 0));//just above
            splashDamage.Enqueue((1, 0));//just down
            splashDamage.Enqueue((0, -1));//just left
            splashDamage.Enqueue((0, 1));//just right
            splashDamage.Enqueue((0, 0));//current number

            int variationsCount = splashDamage.Count;

            for (int spread = 0; spread < variationsCount; spread++)
            {
                try
                {
                    if (currentMatrix[row + splashDamage.Peek().dmgRow, col + splashDamage.Peek().dmgCol] > 0)
                    {
                        currentMatrix[row + splashDamage.Peek().dmgRow, col + splashDamage.Peek().dmgCol] -= damage;
                    }
                    splashDamage.Dequeue();
                }
                catch (Exception)
                {
                    splashDamage.Dequeue();
                    continue;
                }
            }

            return currentMatrix;
        }

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            //seed matrix

            for (int row = 0; row < matrixSize; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            //get coordinates pair
            string[] stringCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<(int row, int col)> coordinates = new Queue<(int, int)>();

            for (int i = 0; i < stringCoordinates.Length; i++)
            {
                int row = int.Parse(stringCoordinates[i][0].ToString());
                int col = int.Parse(stringCoordinates[i][2].ToString());

                coordinates.Enqueue((row, col));
            }

            while (coordinates.Count > 0)
            {
                matrix = TriggerBomb(matrix, coordinates.Peek().row, coordinates.Peek().col);

                coordinates.Dequeue();
            }

            int aliveCells = 0;
            int aliveCellsValueSum = 0;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] > 0)
                    {
                        aliveCells++;
                        aliveCellsValueSum += matrix[i, k];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsValueSum}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[i, k] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
