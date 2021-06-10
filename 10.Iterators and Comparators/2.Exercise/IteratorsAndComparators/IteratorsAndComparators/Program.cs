using System;

namespace IteratorsAndComparators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] elements = new string[commandArgs.Length - 1];

            for (int i = 1; i < elements.Length + 1; i++)
            {
                elements[i - 1] = commandArgs[i];
            }

            ListyIterator<string> listy = new ListyIterator<string>(elements);

            string nextCommand = Console.ReadLine();

            while (!nextCommand.ToLower().Contains("end"))
            {
                if (nextCommand.Contains("Move"))
                {
                    Console.WriteLine(listy.Move());
                }
                else if (nextCommand =="Print")
                {
                    listy.Print();
                }
                else if (nextCommand == "PrintAll")
                {
                    listy.PrintAll();
                }
                else if (nextCommand.Contains("HasNext"))
                {
                    Console.WriteLine(listy.HasNext());
                }

                nextCommand = Console.ReadLine();
            }
        }
    }
}
