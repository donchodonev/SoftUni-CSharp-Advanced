using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static Func<int, int, List<int>> GetNumsFromTo = (lower, upper) =>
        {
            List<int> nums = new List<int>();

            for (int i = lower; i <= upper; i++)
            {
                nums.Add(i);
            }

            return nums;
        };

        static Action<List<int>, string> Print = (list, condition) =>
        {
            if (condition == "even")
            {
                foreach (var num in list.Where(x => x % 2 == 0))
                {
                    Console.Write($"{num} ");
                };
            }
            else if (condition == "odd")
            {
                foreach (var num in list.Where(x => x % 2 != 0))
                {
                    Console.Write($"{num} ");
                };
            }
        };

        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startNum = inputArgs[0];
            int endNum = inputArgs[1];

            string evenOrOdd = Console.ReadLine();

            List<int> numbers = GetNumsFromTo(startNum, endNum);

            Print(numbers, evenOrOdd);
        }
    }
}
