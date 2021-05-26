using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("resources\\Input.txt");

            using (reader)
            {
                int counter = 1;

                string line = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter("resources\\output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
