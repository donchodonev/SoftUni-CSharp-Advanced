using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rowLength = size[0];
            int colLength = size[1];

            int[,] matrix = new int[rowLength,colLength ];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(rowLength);
            Console.WriteLine(colLength);
            Console.WriteLine(sum);

        }
    }
}
