using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] uppercaseWords =
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word[0] == word.ToUpper()[0])
                .ToArray();

            foreach (var word in uppercaseWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
