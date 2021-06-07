using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] customArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                customArray[i] = item;
            }
            return customArray;
        }
    }
}
