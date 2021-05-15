using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numStack = new Stack<int>();

            int iterations = int.Parse(Console.ReadLine());

            for (int i = 0; i < iterations; i++)
            {
                int[] inputArgs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (inputArgs[0] == 1)
                {
                    numStack.Push(inputArgs[1]);
                    continue;
                }
                if (inputArgs[0] == 2)
                {
                    numStack.Pop();
                    continue;
                }
                if (inputArgs[0] == 3 && numStack.Count > 0)
                {
                    Console.WriteLine(numStack.Max());
                    continue;
                }
                if (inputArgs[0] == 4 && numStack.Count > 0)
                {
                    Console.WriteLine(numStack.Min());
                }
            }

            while (numStack.Count > 1)
            {
                Console.Write($"{numStack.Pop()}, ");
            }
            Console.Write($"{numStack.Pop()}");

        }
    }
}
