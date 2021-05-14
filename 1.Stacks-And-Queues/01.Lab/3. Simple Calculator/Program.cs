using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            input = input.Reverse().ToArray();

            Stack<string> numsAndOperators = new Stack<string>();

            foreach (var item in input)
            {
                numsAndOperators.Push(item);
            }

            while (numsAndOperators.Count > 1)
            {
                int firstNum = int.Parse(numsAndOperators.Pop());
                string operatorSign = numsAndOperators.Pop();
                int secondNum = int.Parse(numsAndOperators.Pop());

                if (operatorSign == "+")
                {
                    numsAndOperators.Push((firstNum + secondNum).ToString());
                }
                else
                {
                    numsAndOperators.Push((firstNum - secondNum).ToString());
                }
            }

            Console.WriteLine(numsAndOperators.Peek());
        }
    }
}
