using System;
using System.Collections.Generic;

namespace Generic_Box_of_String
{
    public class Box<T>
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
        public static void Swap(List<Box<T>> listOfBox, int indexOne, int indexTwo)
        {
            Box<T> firstElement = listOfBox[indexOne];
            Box<T> secondElement = listOfBox[indexTwo];

            listOfBox[indexOne] = secondElement;
            listOfBox[indexTwo] = firstElement;
        }
    }
}
