using System;
using System.Collections.Generic;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> kniteMoves = new Queue<int[]>();

            kniteMoves.Enqueue(new int[2] { -1, -2 });//up and two left
            kniteMoves.Enqueue(new int[2] { 1, -2 });//down and two left
            kniteMoves.Enqueue(new int[2] { -2, -1 });//twice up one left
            kniteMoves.Enqueue(new int[2] { 2, -1 });//twice down one left
            kniteMoves.Enqueue(new int[2] { -2, 1 });//twice up one right
            kniteMoves.Enqueue(new int[2] { 2, 1 });//twice down one right
            kniteMoves.Enqueue(new int[2] { -1, 2 });//one up two right
            kniteMoves.Enqueue(new int[2] { 1, 2 });//one down two right

            int matrixSize = int.Parse(Console.ReadLine());

            string[,] matrix = new string[matrixSize, matrixSize];

            //seed matrix

            for (int i = 0; i < matrixSize; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int k = 0; k < matrixSize; k++)
                {
                    matrix[i, k] = input[k].ToString();
                }

            }

            bool foundHit = true;

            int mostHits = 0;

            int saveMostHits = 0;

            int bestRow = int.MinValue;

            int bestCol = int.MinValue;

            int counter = 0;

            while (foundHit == true)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        if (matrix[i, k] == "K")
                        {
                            for (int j = 0; j < kniteMoves.Count; j++)
                            {
                                int upOrDown = kniteMoves.Peek()[0];
                                int leftOrRight = kniteMoves.Peek()[1];

                                kniteMoves.Enqueue(kniteMoves.Dequeue());

                                try
                                {
                                    if (matrix[i + upOrDown, k + leftOrRight] == "K")
                                    {
                                        mostHits++;
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }

                        }
                        if (mostHits > 0)
                        {
                            foundHit = true;
                        }
                        else
                        {
                            foundHit = false;
                        }
                        if (mostHits > saveMostHits)
                        {
                            bestRow = i;
                            bestCol = k;
                            saveMostHits = mostHits;
                        }
                        mostHits = 0;
                    }
                }

                if (foundHit = true && bestRow != int.MinValue && bestCol != int.MinValue)
                {
                    matrix[bestRow, bestCol] = "0";
                    counter++;
                }

                saveMostHits = 0;

                bestRow = int.MinValue;

                bestCol = int.MinValue;
            }
            Console.WriteLine(counter);
        }
    }
}