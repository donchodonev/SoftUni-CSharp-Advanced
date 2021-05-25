using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> numDict = new Dictionary<double, int>();

            foreach (var num in values)
            {
                if (numDict.ContainsKey(num))
                {
                    numDict[num]++;
                }
                else
                {
                    numDict.Add(num, 1);
                }
            }

            foreach (var kvp in numDict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
