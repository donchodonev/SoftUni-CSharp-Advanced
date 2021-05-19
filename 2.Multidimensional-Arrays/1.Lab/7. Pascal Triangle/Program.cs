using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[n][];

            for (long row = 0; row < n; row++)
            {
                if (row == 0)
                {
                    pascalTriangle[row] = new long[1] { 1 };
                    continue;
                }

                for (long col = 0; col < row + 1; col++)
                {
                    long topLeft = 0;
                    long topRight = 0;


                    if (col == 0)
                    {
                        topLeft = 0;
                        pascalTriangle[row] = new long[row + 1];
                    }
                    else
                    {
                        topLeft = pascalTriangle[row - 1][col - 1];
                    }

                    if (col == row)
                    {
                        topRight = 0;
                    }
                    else
                    {
                        topRight = pascalTriangle[row - 1][col];
                    }

                    pascalTriangle[row][col] = topRight + topLeft;
                }
            }


            for (int row = 0; row < pascalTriangle.GetLength(0); row++)
            {
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    Console.Write(pascalTriangle[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
