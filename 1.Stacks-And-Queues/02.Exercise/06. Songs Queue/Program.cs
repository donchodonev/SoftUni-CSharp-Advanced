using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            string commandArgs = Console.ReadLine();

            while (songs.Count > 0)
            {
                if (commandArgs[0] == 'P')
                {
                    songs.Dequeue();
                }
                else if (commandArgs[0] == 'S')
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else
                {
                    string songNameValue = commandArgs.Split("Add ",StringSplitOptions.RemoveEmptyEntries)[0];

                    if (songs.Contains(songNameValue))
                    {
                        Console.WriteLine($"{songNameValue} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songNameValue);
                    }
                }

                commandArgs = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
