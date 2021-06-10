using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Stack<int> myStack = new Stack<int>();

            while (!command.Contains("END"))
            {
                if (command.Contains("Push"))
                {
                    int[] intsToPush = command
                        .Substring(4)
                        .Split(", ")
                        .Select(int.Parse)
                        .ToArray();

                    myStack.Push(intsToPush);
                }
                else
                {
                    myStack.Pop();
                }

                command = Console.ReadLine();
            }

            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
