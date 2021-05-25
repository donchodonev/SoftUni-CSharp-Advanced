using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentCountryCity = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = inputArgs[0];
                string country = inputArgs[1];
                string city = inputArgs[2];


                if (continentCountryCity.ContainsKey(continent))
                {
                    if (continentCountryCity[continent].ContainsKey(country))
                    {
                        continentCountryCity[continent][country].Add(city);
                    }
                    else
                    {
                        continentCountryCity[continent].Add(country, new List<string> { city });
                    }
                }
                else
                {
                    continentCountryCity.Add(continent, new Dictionary<string, List<string>>());
                    continentCountryCity[continent].Add(country, new List<string> { city });
                }
            }

            foreach (var continent in continentCountryCity)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
