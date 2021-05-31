using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] numbers = Enumerable.Range(1, int.Parse(Console.ReadLine())).ToArray();
            
            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> predicate = (num, divider) =>
            {
                return num % divider == 0;
            };

            foreach (var number in numbers)
            {
                if (dividers.All(divider => predicate(number, divider)))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
