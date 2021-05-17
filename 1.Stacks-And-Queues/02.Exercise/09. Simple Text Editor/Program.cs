using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());

            Stack<string> text = new Stack<string>();

            for (int i = 0; i < operations; i++)
            {
                string operation = Console.ReadLine();

                string type = operation.Split()[0];

                string variable = string.Empty;

                if (type != "4")
                {
                    variable = operation.Split()[1];
                }


                if (type.Equals("1"))
                {
                    if (text.Count > 0)
                    {
                        text.Push(text.Peek() + variable);
                    }
                    else
                    {
                        text.Push(variable);
                    }
                }
                else if (type.Equals("2"))
                {
                    string textToPush = string.Empty;

                    text.Push(text.Peek().Substring(0, text.Peek().Length - int.Parse(variable)));
                }
                else if (type.Equals("3"))
                {
                    Console.WriteLine($"{text.Peek()[int.Parse(variable) - 1]}");
                }
                else
                {
                    if (text.Count > 0)
                    {
                        text.Pop();
                    }
                }
            }
        }
    }
}
