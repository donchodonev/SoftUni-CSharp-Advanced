using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Stack<T> Elements { get; set; } = new Stack<T>();
        public int Count { get => Elements.Count; }
        public void Add(T element)
        {
            Elements.Push(element);
        }
        public T Remove()
        {
            return Elements.Pop();
        }
    }
}
