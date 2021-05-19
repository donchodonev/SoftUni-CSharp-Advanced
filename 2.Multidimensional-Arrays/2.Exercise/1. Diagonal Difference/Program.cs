using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {

                int[] colValue = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = colValue[col];
                }
            }

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int vafli = 0; vafli < n; vafli++)
            {
                firstDiagonal += matrix[vafli, vafli];
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = n-1; col > 0; col--)
                {
                    secondDiagonal += matrix[row, col - row];
                    break;
                }
            }

            Console.WriteLine($"{Math.Abs(firstDiagonal-secondDiagonal)}");
        }
    }
}
