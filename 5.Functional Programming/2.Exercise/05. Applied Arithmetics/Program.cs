using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static Action<List<int>, string> DoMath = (listOfInts, condition) =>
        {
            switch (condition)
            {
                case "add":
                    for (int i = 0; i < listOfInts.Count; i++)
                    {
                        listOfInts[i] += 1;
                    }
                    break;
                case "subtract":
                    for (int i = 0; i < listOfInts.Count; i++)
                    {
                        listOfInts[i] -= 1;
                    }
                    break;
                case "multiply":
                    for (int i = 0; i < listOfInts.Count; i++)
                    {
                        listOfInts[i] *= 2;
                    }
                    break;
                default:
                    Console.WriteLine(string.Join(' ', listOfInts));
                    break;
            }
        };
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            string command = Console.ReadLine();

            while (command != "end")
            {
                DoMath(numbers, command);

                command = Console.ReadLine();
            }
        }
    }
}
