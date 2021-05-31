using System;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {

        static void Main(string[] args)
        {
            Action<string[]> print = words =>
            {
                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
            };

            print(Console.ReadLine().Split());
        }
    }
}
