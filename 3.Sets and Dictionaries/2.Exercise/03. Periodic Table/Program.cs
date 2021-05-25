using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] currentElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in currentElements)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ', elements));
        }
    }
}
