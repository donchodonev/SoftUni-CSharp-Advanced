using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = inputArgs[0];

                string[] clothesType = inputArgs[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                for (int v = 0; v < clothesType.Length; v++)
                {
                    if (wardrobe.ContainsKey(color))
                    {
                        if (wardrobe[color].ContainsKey(clothesType[v]))
                        {
                            wardrobe[color][clothesType[v]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothesType[v], 1);
                        }
                    }
                    else
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                        wardrobe[color].Add(clothesType[v],1);
                    }
                }
            }

            string[] itemNeeded = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string colorWanted = itemNeeded[0];
            string clothingType = itemNeeded[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clothing in color.Value)
                {
                    if (color.Key == colorWanted && clothing.Key == clothingType)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }
                }
            }
        }
    }
}
