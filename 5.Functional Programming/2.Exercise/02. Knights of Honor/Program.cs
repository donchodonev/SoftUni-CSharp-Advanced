using System;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printSir = words =>
            {
                foreach (var word in words)
                {
                    Console.WriteLine($"Sir {word}");
                }
            };

            printSir(Console.ReadLine().Split());
        }
    }
}
