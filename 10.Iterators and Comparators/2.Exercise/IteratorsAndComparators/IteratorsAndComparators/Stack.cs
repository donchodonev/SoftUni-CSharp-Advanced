using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> Collection = new List<T>();
        public void Push(T[] elements)
        {
            foreach (T el in elements)
            {
                Collection.Add(el);
            }
        }
        public T Pop()
        {
            if (Collection.Count == 0)
            {
                Console.WriteLine("No elements");
                return default(T);
            }
            T elementToRemove = Collection[Collection.Count - 1];

            Collection.RemoveAt(Collection.Count - 1);

            return elementToRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Collection.Count - 1; i >= 0; i--)
            {
                yield return Collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
