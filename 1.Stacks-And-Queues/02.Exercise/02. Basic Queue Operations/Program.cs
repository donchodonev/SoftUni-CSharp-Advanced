using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (input[0] == input[1])
            {
                Console.WriteLine(0);
                return;
            }

            Queue<int> nums = new Queue<int>();

            int[] numsToPush = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int smallestElementInTheStack = int.MaxValue;
            bool isFound = false;

            //pushing
            for (int i = 0; i < input[0]; i++)
            {
                nums.Enqueue(numsToPush[i]);
            }
            //poppping
            for (int i = 0; i < input[1]; i++)
            {
                int currentNum = nums.Dequeue();
            }
            //logic
            while (nums.Count > 0)
            {
                int currentNum = nums.Peek();
                if (currentNum == input[2])
                {
                    isFound = true;
                }
                if (currentNum < smallestElementInTheStack)
                {
                    smallestElementInTheStack = currentNum;
                }
                nums.Dequeue();
            }
            //print
            if (!isFound)
            {
                Console.WriteLine($"{smallestElementInTheStack}");
            }
            else
            {
                Console.WriteLine("true");
            }
        }
    }
}
