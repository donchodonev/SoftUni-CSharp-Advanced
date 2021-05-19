using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            //first occurance coordinates

            int fOccRowCoordinate = 0;
            int fOccColCoordinate = 0;

            // fill matrix
            for (int row = 0; row < n; row++)
            {
                char[] inputValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputValues[col];
                }
            }
            //read matrix

            bool charNotFound = true;
            char specialSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < n && charNotFound; row++)
            {
                for (int col = 0; col < n && charNotFound; col++)
                {
                    if (matrix[row,col] == specialSymbol)
                    {
                        fOccRowCoordinate = row;
                        fOccColCoordinate = col;
                        charNotFound = false;
                    }
                }
            }

            if (charNotFound)
            {
                Console.WriteLine($"{specialSymbol} does not occur in the matrix");
                return;
            }

            Console.WriteLine($"({fOccRowCoordinate}, {fOccColCoordinate})");

        }
    }
}
