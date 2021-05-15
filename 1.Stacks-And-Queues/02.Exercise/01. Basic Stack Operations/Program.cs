using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            //0 = num of elements to push to the stack
            //1 = number of elements to pop from the stack
            //2 = element to look for in the stack

            int[] input = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (input[0] ==input[1])
            {
                Console.WriteLine(0);
                return;
            }

            Stack<int> nums = new Stack<int>();

            int[] numsToPush = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int smallestElementInTheStack = int.MaxValue;
            bool isFound = false;

            //pushing
            for (int i = 0; i < input[0]; i++)
            {
                nums.Push(numsToPush[i]);
            }
            //poppping
            for (int i = 0; i < input[1]; i++)
            {
                int currentNum = nums.Pop();
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
                nums.Pop();
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
