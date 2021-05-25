using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            char[] inputChars = Console.ReadLine().ToCharArray();

            foreach (var character in inputChars)
            {
                if (chars.ContainsKey(character))
                {
                    chars[character]++;
                }
                else
                {
                    chars.Add(character, 1);
                }
            }

            foreach (var character in chars)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }

        }
    }
}
