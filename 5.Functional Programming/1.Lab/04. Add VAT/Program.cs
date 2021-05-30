using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] priceWithVatAdded = Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .Select(num => num * 1.2m)
                .ToArray();


            foreach (var num in priceWithVatAdded)
            {
                Console.WriteLine($"{num:F2}");
            }
        }
    }
}
