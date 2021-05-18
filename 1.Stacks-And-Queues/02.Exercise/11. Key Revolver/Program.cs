using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());

            int sizeOfBarrel = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Queue<int> locksQueue = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int intelligence = int.Parse(Console.ReadLine());

            int shootCount = 0;

            int shotsFired = 0;

            while (true)
            {
                if (bulletStack.Count == 0 || locksQueue.Count == 0)
                {
                    if (bulletStack.Count == 0 && locksQueue.Count > 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count()}");
                        return;
                    }
                    if (locksQueue.Count == 0)
                    {
                        Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${intelligence - (shotsFired * bulletPrice)}");
                        return;
                    }
                }

                //start shooting

                if (bulletStack.Pop() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                shootCount++;
                shotsFired++;

                if (shootCount == sizeOfBarrel && bulletStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shootCount = 0;
                }
            }
        }
    }
}
