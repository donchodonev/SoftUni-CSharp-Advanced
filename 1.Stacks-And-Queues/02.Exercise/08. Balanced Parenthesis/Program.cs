using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> open = new Stack<char>();

            bool isValid = true;

            foreach (char bracket in input)
            {
                if (bracket == '(' || bracket == '[' || bracket == '{')
                {
                    open.Push(bracket);
                }
                else
                {
                    if (open.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    else if (open.Peek().ToString() + bracket.ToString() == "()")
                    {
                        open.Pop();
                        continue;
                    }
                    else if (open.Peek().ToString() + bracket.ToString() == "[]")
                    {
                        open.Pop();
                        continue;
                    }
                    else if (open.Peek().ToString() + bracket.ToString() == "{}")
                    {
                        open.Pop();
                        continue;
                    }

                }
            }

            if (isValid && open.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
