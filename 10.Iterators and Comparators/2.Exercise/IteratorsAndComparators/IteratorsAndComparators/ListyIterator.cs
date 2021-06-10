using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>
    {
        private int index;
        public ListyIterator(params T[] colItems)
        {
            Create(colItems);
        }
        public List<T> Collection { get; set; }

        public bool HasNext()
        {
            int nextIndex = index + 1;

            if (nextIndex >= Collection.Count)
            {
                return false;
            }
            return true;
        }

        public void Create(params T[] items)
        {
            index = 0;
            Collection = new List<T>(items);
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine($"{Collection[index]}");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
                Environment.Exit(0);
            }
        }
    }
}
