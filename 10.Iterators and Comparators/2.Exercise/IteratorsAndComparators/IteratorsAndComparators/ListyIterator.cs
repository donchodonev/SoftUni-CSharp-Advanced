using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        public ListyIterator(params T[] colItems)
        {
            Create(colItems);
        }
        private List<T> Collection { get; set; }

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void PrintAll()
        {
            try
            {
                Console.WriteLine(string.Join(' ', Collection));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in Collection)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
