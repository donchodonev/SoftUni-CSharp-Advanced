using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        public static int[,] TriggerBomb (int [,] matrix, int row, int col)
        {
            //assing matrix
            int[,] currentMatrix = matrix;

            //get cells damage value
            int damage = matrix[row, col];

            //skip bombing if bomb value is less than 0
            if (damage <= 0)
            {
                return currentMatrix;
            }

            //initialise tuple queue with coordinates surrounding bomb
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

            //sepeate coordinates' count as coorinates' count will get dynamically reduce in the for-loop
            int variationsCount = splashDamage.Count;

            //modify bomb index to go through it's surrounding elements
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
                // if index out of range - dequeue coordinates and continue
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
            //get matrix size
            int matrixSize = int.Parse(Console.ReadLine());

            //initialise matrix
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

            //get coordinates pair from console
            string[] stringCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //initialise a tuple queue keeping the row and col value where the bomb will be at
            Queue<(int row, int col)> coordinates = new Queue<(int, int)>();

            //seed tuple queue
            for (int i = 0; i < stringCoordinates.Length; i++)
            {
                int row = int.Parse(stringCoordinates[i][0].ToString());
                int col = int.Parse(stringCoordinates[i][2].ToString());

                coordinates.Enqueue((row, col));
            }

            //while coordinates exist - keep bombing
            while (coordinates.Count > 0)
            {
                //assign bombed matrix to current matrix
                //NB! ()
                matrix = TriggerBomb(matrix, coordinates.Peek().row, coordinates.Peek().col);

                coordinates.Dequeue();
            }

            int aliveCells = 0;
            int aliveCellsValueSum = 0;

            //populate aliveCells count and aliveCellsValueSum
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

            //print count and sum
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsValueSum}");

            //print matrix
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
