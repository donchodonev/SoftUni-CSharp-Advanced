using System;
using System.Collections.Generic;
using System.Linq;
using Generic_Box_of_String;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> listOfBoxes = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                listOfBoxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            Box<double> elementToCompare = new Box<double>(double.Parse(Console.ReadLine()));

            Console.WriteLine(Compare(listOfBoxes,elementToCompare));


        }
        private static void Swap<T>(List<Box<T>> listOfBox, int indexOne, int indexTwo)
            where T : IComparable
        {
            var firstElement = listOfBox[indexOne];
            var secondElement = listOfBox[indexTwo];

            listOfBox[indexOne] = secondElement;
            listOfBox[indexTwo] = firstElement;
        }

        private static int Compare<T>(List<Box<T>> boxes, Box<T> boxToCompare)
            where T:IComparable
        {
            int count = 0;

            foreach (var box in boxes)
            {
                if (box.Value.CompareTo(boxToCompare.Value) == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
