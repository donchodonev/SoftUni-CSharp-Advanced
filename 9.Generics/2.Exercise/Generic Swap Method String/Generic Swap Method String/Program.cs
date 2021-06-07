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

            List<Box<string>> listOfBoxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                listOfBoxes.Add(new Box<string>(Console.ReadLine()));
            }

            int [] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Box<string>.Swap(listOfBoxes, indexes[0], indexes[1]);

            listOfBoxes.ForEach(box => Console.WriteLine(box));
        }
    }
}
