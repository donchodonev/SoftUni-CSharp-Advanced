using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());


            int rackSize = int.Parse(Console.ReadLine());

            int rackCount = 1;

            int clothesSizeSum = 0;

            while (clothes.Count > 0)
            {
                if (clothes.Peek() + clothesSizeSum <= rackSize)
                {
                    clothesSizeSum += clothes.Pop();
                }
                else
                {
                    rackCount++;
                    clothesSizeSum = 0;
                    clothesSizeSum += clothes.Pop();
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}
