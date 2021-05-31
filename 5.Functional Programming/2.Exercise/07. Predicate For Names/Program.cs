using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static Action<List<string>, int> PrintName = (names, length) =>
        {
            foreach (var name in names)
            {
                if (name.Length <= length)
                {
                    Console.WriteLine(name);
                }
            }
        };
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            PrintName(names, n);
        }
    }
}
