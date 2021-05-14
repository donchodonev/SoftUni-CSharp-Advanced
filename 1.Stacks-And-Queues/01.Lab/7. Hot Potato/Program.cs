using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split().ToArray());

            int n = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i == n)
                    {
                        Console.WriteLine($"Removed {kids.Dequeue()}");
                    }
                    else
                    {
                        kids.Enqueue(kids.Dequeue());
                    }
                }
            }
            Console.WriteLine($"Last is {kids.Peek()}");
        }
    }
}
