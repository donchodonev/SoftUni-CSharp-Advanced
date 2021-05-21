using System;
using System.Collections.Generic;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int r = int.Parse(firstInput[0]);
            int c = int.Parse(firstInput[1]);

            char[,] matrix = new char[r, c];

            (int row, int col) playerCoordinates = (0, 0);

            for (int row = 0; row < r; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerCoordinates.row = row;
                        playerCoordinates.col = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToUpper().ToCharArray();

            Queue<char> direction = new Queue<char>();

            foreach (var item in directions)
            {
                direction.Enqueue(item);
            }

            bool isPlayerDead = false;
            bool isOutOfMatrix = false;

            int left = -1;
            int right = 1;
            int up = -1;
            int down = 1;

            bool cycle = true;

            while (cycle)
            {
                if (isOutOfMatrix)
                {
                    cycle = false;
                    break;
                }

                if (isPlayerDead)
                {
                    cycle = false;
                    break;
                }

                char currentDirection = direction.Dequeue();

                (int row, int col) tempPlayerCoordinates = playerCoordinates;

                if (currentDirection == 'L')
                {
                    tempPlayerCoordinates.col += left;
                }
                else if (currentDirection == 'R')
                {
                    tempPlayerCoordinates.col += right;

                }
                else if (currentDirection == 'U')
                {
                    tempPlayerCoordinates.row += up;

                }
                else if (currentDirection == 'D')
                {
                    tempPlayerCoordinates.row += down;
                }

                if (tempPlayerCoordinates.row < 0 || tempPlayerCoordinates.row >= matrix.GetLength(0))
                {
                    isOutOfMatrix = true;
                    matrix[playerCoordinates.row, playerCoordinates.col] = '.';
                }
                else if (tempPlayerCoordinates.col < 0 || tempPlayerCoordinates.col >= matrix.GetLength(1))
                {
                    isOutOfMatrix = true;
                    matrix[playerCoordinates.row, playerCoordinates.col] = '.';
                }
                else if (matrix[tempPlayerCoordinates.row, tempPlayerCoordinates.col] == 'B')
                {
                    isPlayerDead = true;
                    matrix[playerCoordinates.row, playerCoordinates.col] = '.';
                    playerCoordinates = tempPlayerCoordinates;
                }
                else if (tempPlayerCoordinates.row >= 0
                    && tempPlayerCoordinates.row < matrix.GetLength(0)
                    && tempPlayerCoordinates.col >= 0
                    && tempPlayerCoordinates.col < matrix.GetLength(1))
                {
                    matrix[playerCoordinates.row, playerCoordinates.col] = '.';
                    playerCoordinates = tempPlayerCoordinates;
                    matrix[playerCoordinates.row, playerCoordinates.col] = 'P';
                }

                Queue<(int, int)> bunnyCoordinates = new Queue<(int, int)>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunnyCoordinates.Enqueue((row, col));
                        }
                    }
                }

                while (bunnyCoordinates.Count > 0)
                {
                    (int row, int col) currentBunny = bunnyCoordinates.Dequeue();

                    try
                    {
                        if (matrix[currentBunny.row + up, currentBunny.col] == 'P')
                        {
                            isPlayerDead = true;
                        }
                        matrix[currentBunny.row + up, currentBunny.col] = 'B';
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (matrix[currentBunny.row + down, currentBunny.col] == 'P')
                        {
                            isPlayerDead = true;
                        }
                        matrix[currentBunny.row + down, currentBunny.col] = 'B';
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (matrix[currentBunny.row, currentBunny.col + left] == 'P')
                        {
                            isPlayerDead = true;
                        }
                        matrix[currentBunny.row, currentBunny.col + left] = 'B';
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (matrix[currentBunny.row, currentBunny.col + right] == 'P')
                        {
                            isPlayerDead = true;
                        }
                        matrix[currentBunny.row, currentBunny.col + right] = 'B';
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            if (isOutOfMatrix)
            {
                Console.WriteLine($"won: {playerCoordinates.row} {playerCoordinates.col}");
            }
            else if (isPlayerDead)
            {
                Console.WriteLine($"dead: {playerCoordinates.row} {playerCoordinates.col}");
            }
        }
    }
}
