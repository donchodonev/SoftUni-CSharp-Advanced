using System;
using System.Collections.Generic;

namespace Generic_Box_of_String
{
    public class Box<T>
        where T : IComparable
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }
}
