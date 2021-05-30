using System;

namespace _5._Filter_by_Age
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
         static Action<Person> PrintPerson(string format)
        {
            if (format == "name age")
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
            else if (format == "name")
            {
                return p => Console.WriteLine($"{p.Name}");
            }
            else if (format == "age")
            {
                return p => Console.WriteLine($"{p.Age}");
            }
            else return null;
        }

        static Func<Person, bool> Condition(string condition, int age)
        {
            if (condition == "younger")
            {
                return person => person.Age < age;
            }
            else if (condition == "older")
            {
                return person => person.Age >= age;
            }
            else
            {
                return null;
            }
        }

        static void PrintPeople(Person[] people,Func<Person, bool> condition, Action<Person> printPerson )
        {
            foreach (var person in people)
            {
                if (condition(person))
                {
                    printPerson(person);
                }
            }
        }


        static void Main(string[] args)
        {
            //get input count
            int n = int.Parse(Console.ReadLine());

            //initialise Person var
            Person[] people = new Person[n];

            //seed Person array
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                people[i] = new Person();
                people[i].Name = input[0];
                people[i].Age = int.Parse(input[1]);
            }

            string currentCondition = Console.ReadLine();
            int currentAge = int.Parse(Console.ReadLine());

            Func<Person, bool> condition = Condition(currentCondition, currentAge);

            Action<Person> print = PrintPerson(Console.ReadLine());

            PrintPeople(people, condition, print);

        }
    }
}