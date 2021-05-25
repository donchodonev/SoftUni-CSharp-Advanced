using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Vlogger
    {
        public HashSet<string> Followers { get; set; } = new HashSet<string>();
        public HashSet<string> Following { get; set; } = new HashSet<string>();

        public Vlogger()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            //key is who the vlogger is already following
            //value is who is following the vlogger


            string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (inputArgs.Length != 1)
            {
                string name = inputArgs[0];

                string command = string.Empty;

                string vloggerBeingFollowed = inputArgs[2];

                if (inputArgs.Length == 4) // means someone is joining
                {
                    command = "join";
                }
                else
                {
                    command = "follow";
                }

                //add vlogger

                if (command == "join")
                {
                    vloggers.TryAdd(name, new Vlogger());
                }
                //add following
                else
                {
                    if (vloggers.ContainsKey(name) && vloggers.ContainsKey(vloggerBeingFollowed) && name != vloggerBeingFollowed)
                    {
                        vloggers[name].Following.Add(vloggerBeingFollowed);

                        vloggers[vloggerBeingFollowed].Followers.Add(name);
                    }
                }

                inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
