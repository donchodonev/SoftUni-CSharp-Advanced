using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Lake myLake = new Lake(nums);

            Console.WriteLine(string.Join(", ", myLake));
        }
    }
}
