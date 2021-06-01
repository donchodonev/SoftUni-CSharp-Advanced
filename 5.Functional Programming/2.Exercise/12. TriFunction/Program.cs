using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumOfChars = int.Parse(Console.ReadLine());

            Func<string, int, bool> isCharSumEqualTo = (name, sumOfChars) =>
            {
                int sum = 0;

                foreach (var character in name)
                {
                    sum += (int)character;
                }
                return sum >= sumOfChars;
            };

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(names.FirstOrDefault(name => isCharSumEqualTo(name, sumOfChars)));
        }
    }
}
