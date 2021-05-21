using System;
using System.Linq;
namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            //read matrix size
            int n = int.Parse(Console.ReadLine());

            //initialise matrix
            string[,] field = new string[n, n];

            //get commands
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //seed matrix
            for (int row = 0; row < n; row++)
            {
                string [] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = input[col];
                }
            }

            //values storage
            int coalCollected = 0;
            int coalCount = 0;
            (int row, int col) exitIndex = (0, 0);

            //find start index and make it the current one for the rest of the app
            //find coal count
            //find exit index
            (int row, int col) currentIndex = (0, 0);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (field[row, col] == "s")
                    {
                        currentIndex.row = row;
                        currentIndex.col = col;
                    }
                    if (field[row, col] == "c")
                    {
                        coalCount++;
                    }
                    if (field[row, col] == "e")
                    {
                        exitIndex.row = row;
                        exitIndex.col = col;
                    }
                }
            }

            //go through the commands
            for (int commandIterator = 0; commandIterator < commands.Length; commandIterator++)
            {
                //clone index for safe keeping
                (int row, int col) cloneIndex = currentIndex;

                if (commands[commandIterator] == "up")//go up
                {
                    currentIndex.row -= 1;
                }
                else if (commands[commandIterator] == "down")//go down
                {
                    currentIndex.row += 1;
                }
                else if (commands[commandIterator] == "left")//go left
                {
                    currentIndex.col -= 1;
                }
                else if (commands[commandIterator] == "right")//go right
                {
                    currentIndex.col += 1;
                }

                //check if index is out of bounds

                if (currentIndex.row < 0 || currentIndex.row >= field.GetLength(0) || currentIndex.col < 0 || currentIndex.col >= field.GetLength(1))
                {
                    currentIndex = cloneIndex;
                }

                if (field[currentIndex.row,currentIndex.col] == "*")
                {
                    continue;
                }
                else if (field[currentIndex.row, currentIndex.col] == "c")
                {
                    coalCollected++;
                    field[currentIndex.row, currentIndex.col] = "*";

                    if (coalCount == coalCollected)
                    {
                        Console.WriteLine($"You collected all coals! ({currentIndex.row}, {currentIndex.col})");
                        return;
                    }
                }
                else if (field[currentIndex.row, currentIndex.col] == "e")
                {
                    Console.WriteLine($"Game over! ({exitIndex.row}, {exitIndex.col})");
                    return;
                }
            }

            Console.WriteLine($"{coalCount - coalCollected} coals left. ({currentIndex.row}, {currentIndex.col})");

        }
    }
}