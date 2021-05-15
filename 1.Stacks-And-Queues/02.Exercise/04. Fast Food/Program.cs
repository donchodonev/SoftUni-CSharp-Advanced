using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            Queue<int> ordersQuantity = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Console.WriteLine(ordersQuantity.Max());

            while (ordersQuantity.Count > 0)
            {
                if (ordersQuantity.Peek() <= quantityOfFood)
                {
                    quantityOfFood -= ordersQuantity.Dequeue();

                    if (ordersQuantity.Count == 0)
                    {
                        Console.WriteLine("Orders complete");
                        return;
                    }
                }
                else
                {
                    Console.Write("Orders left: ");
                    while (ordersQuantity.Count > 1)
                    {
                        Console.Write($"{ordersQuantity.Dequeue()} ");
                    }
                    Console.Write($"{ordersQuantity.Dequeue()}");
                }
            }
        }
    }
}
