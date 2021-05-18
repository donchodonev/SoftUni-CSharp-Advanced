using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsQueue = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Stack<int> bottleStack = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));


            int wastedWater = 0;
            int currentCup = 0;
            int currentBottle = 0;

            bool onSameCup = false;

            while (true)
            {
                if (cupsQueue.Count == 0 || bottleStack.Count == 0)
                {
                    if (cupsQueue.Count == 0)
                    {
                        Console.WriteLine($"Bottles: {string.Join(' ',bottleStack)}");
                        Console.WriteLine($"Wasted litters of water: {wastedWater}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Cups: {string.Join(' ', cupsQueue)}");
                        Console.WriteLine($"Wasted litters of water: {wastedWater}");
                        return;
                    }
                }

                if (!onSameCup)
                {
                    currentCup = cupsQueue.Peek();
                }

                currentBottle = bottleStack.Pop();

                if (currentBottle - currentCup >= 0)
                {
                    wastedWater += currentBottle - currentCup;
                    cupsQueue.Dequeue();
                    onSameCup = false;
                }
                else
                {
                    currentCup -= currentBottle;
                    onSameCup = true;
                }
            }
        }
    }
}
