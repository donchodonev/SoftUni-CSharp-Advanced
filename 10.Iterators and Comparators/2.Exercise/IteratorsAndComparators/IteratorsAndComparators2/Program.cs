using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<Person> hashSet = new HashSet<Person>();

            SortedSet<Person> sortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                hashSet.Add(new Person(name, age));
                sortedSet.Add(new Person(name, age));
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
