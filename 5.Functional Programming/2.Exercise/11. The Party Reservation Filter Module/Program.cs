using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        //task solution is made to follow functional programming paradigm
        //that's why it's overly built
        //original data stays intact through the filtering process
        public static Func<List<string>, string, List<string>> PersonNameStartsWith = (names, parameter) =>
        {
            return names.Where(name => name.StartsWith(parameter)).ToList();
        };
        public static Func<List<string>, string, List<string>> PersonNameEndsWith = (names, parameter) =>
        {
            return names.Where(name => name.EndsWith(parameter)).ToList();
        };
        public static Func<List<string>, string, List<string>> PersonNameLength = (names, parameter) =>
        {
            return names.Where(name => name.Length == int.Parse(parameter)).ToList();
        };
        public static Func<List<string>, string, List<string>> PersonNameContains = (names, parameter) =>
        {
            return names.Where(name => name.Contains(parameter)).ToList();
        };
        public static Func<List<string>, string, List<string>> GetFilter(string filterName)
        {
            {
                if (filterName == "Starts with")
                {
                    return PersonNameStartsWith;
                }
                else if (filterName == "Ends with")
                {
                    return PersonNameEndsWith;

                }
                else if (filterName == "Length")
                {
                    return PersonNameLength;
                }
                else
                {
                    return PersonNameContains;
                }
            }
        }
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<(Func<List<string>, string, List<string>> Apply, string parameter)> filters = new List<(Func<List<string>, string, List<string>>, string)>();

            string command = Console.ReadLine();
           
            while (command != "Print")
            {
                string[] commandArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string filterName = commandArgs[1];
                string filterAttribute = commandArgs[2];

                if (action == "Add filter")
                {
                    filters.Add((GetFilter(filterName), filterAttribute));
                }
                else
                {
                    filters.RemoveAll(filter => filter == (GetFilter(filterName),filterAttribute));
                }

                command = Console.ReadLine();
            }

            List<string> filteredPeople = people;

            foreach (var filter in filters)
            {
                string filterParameter = filter.parameter;

                foreach (var person in filter.Apply(people, filterParameter))
                {
                    filteredPeople.Remove(person);
                }
            }

            Console.WriteLine(string.Join(' ', filteredPeople));
        }
    }
}
