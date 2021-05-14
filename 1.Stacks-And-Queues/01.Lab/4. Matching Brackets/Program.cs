using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> index = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    index.Push(i);
                }
                else if (expression[i] == ')')
                {
                    Console.WriteLine(expression.Substring(index.Peek(),i - index.Pop() + 1));
                }
            }
        }
    }
}
