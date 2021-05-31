using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static Func<List<int>, int, List<int>> GetDivisibleBy = (listOfInts, divisibleBy) =>
        {
            List<int> filteredNums = new List<int>();

            for (int i = listOfInts.Count - 1; i >= 0; i--)
            {
                if (listOfInts[i] % divisibleBy != 0)
                {
                    filteredNums.Add(listOfInts[i]);
                }
            }

            return filteredNums;
        };

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            numbers = GetDivisibleBy(numbers, int.Parse(Console.ReadLine()));
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
