using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenNums = new Queue<int>(numArr);

            while (evenNums.Count > 1)
            {
                if (evenNums.Peek() % 2 != 0)
                {
                    evenNums.Dequeue();
                }
                else
                {
                    Console.Write($"{evenNums.Dequeue()}, ");
                }
            }
            Console.Write($"{evenNums.Dequeue()}");
        }
    }
}
