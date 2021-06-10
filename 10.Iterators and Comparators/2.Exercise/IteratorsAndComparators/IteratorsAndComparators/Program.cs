using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string name = input.Split()[0];
                int age = int.Parse(input.Split()[1]);
                string town = input.Split()[2];

                people.Add(new Person(name, age, town));

                input = Console.ReadLine();
            }

            int comparisonPersonIndex = int.Parse(Console.ReadLine()) - 1;

            int countOfMatches = 0;
            int totalNumberOfPeople = people.Count;


            foreach (Person person in people)
            {
                if (person.CompareTo(people[comparisonPersonIndex]) == 0)
                {
                    countOfMatches++;
                }
            }

            int numberOfNotEqual = totalNumberOfPeople - countOfMatches;

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {numberOfNotEqual} {totalNumberOfPeople}");
            }
        }
    }
}
