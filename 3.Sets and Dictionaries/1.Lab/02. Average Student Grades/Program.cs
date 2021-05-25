using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> journal = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (journal.ContainsKey(inputArgs[0]))
                {
                    journal[inputArgs[0]].Add(decimal.Parse(inputArgs[1]));
                }
                else
                {
                    journal.Add(inputArgs[0], new List<decimal>());
                    journal[inputArgs[0]].Add(decimal.Parse(inputArgs[1]));
                }
            }

            foreach (var kvp in journal)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(' ',kvp.Value.Select(x => x.ToString("F2")))} (avg: {kvp.Value.Average():F2})");
            }
        }
    }
}
