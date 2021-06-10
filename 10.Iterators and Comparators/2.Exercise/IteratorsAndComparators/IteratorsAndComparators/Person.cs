using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public int CompareTo(Person other)
        {
            int result = 0;

            result += Name.CompareTo(other.Name);
            result += Age.CompareTo(other.Age);
            result += Town.CompareTo(other.Town);

            return result;
        }
    }
}
