using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> reversedInput = new Stack<char>();

            foreach (var character in input)
            {
                reversedInput.Push(character);
            }

            while (reversedInput.Count > 0)
            {
                Console.Write(reversedInput.Pop());
            }
        }
    }
}
