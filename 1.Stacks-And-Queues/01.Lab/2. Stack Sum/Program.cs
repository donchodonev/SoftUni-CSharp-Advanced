using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray(); ;

            Stack<int> nums = new Stack<int>();

            foreach (var num in inputNums)
            {
                nums.Push(num);
            }

            string[] command = Console.ReadLine().ToUpper().Split();

            while (command.Length != 1)
            {
                if (command.Length == 3)
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        nums.Push(int.Parse(command[i]));
                    }
                }
                else
                {
                    int numsToRemove = int.Parse(command[1]);

                    for (int i = 0; i < numsToRemove && numsToRemove <= nums.Count; i++)
                    {
                        nums.Pop();
                    }
                }

                command = Console.ReadLine().ToUpper().Split();
            }

            Console.WriteLine($"Sum: {nums.Sum()}");

        }
    }
}
