using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            string[] inputArgs = Console.ReadLine().Split(", ");

            while (inputArgs[0] != "Revision")
            {
                string shopName = inputArgs[0];
                string product = inputArgs[1];
                double price = double.Parse(inputArgs[2]);

                if (shops.ContainsKey(shopName))
                {
                    shops[shopName].Add(product, price);
                }
                else
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                    shops[shopName].Add(product, price);
                }
                
                inputArgs = Console.ReadLine().Split(", ");
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var kvp in shop.Value)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
