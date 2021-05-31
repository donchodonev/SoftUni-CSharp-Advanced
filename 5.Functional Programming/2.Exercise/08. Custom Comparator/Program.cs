using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static Func<int, int, int> FirstEvenThenOddByAscending = (a, b) =>
            {
                if (a % 2 == 0 && b % 2 !=0)
                {
                    return -1;
                }
                else if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }

                return a.CompareTo(b);
            };
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> firstEvenThenOddByAscending = FirstEvenThenOddByAscending;

            Array.Sort(numbers, (a, b) => firstEvenThenOddByAscending(a, b));

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
