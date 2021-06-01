using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commandArgs = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string condition = commandArgs[1];
                string variable = commandArgs[2];

                Func<List<string>, string, string, List<string>> removeWithCondition = (names, condition, variable) =>
                 {
                     if (condition.ToLower() == "startswith")
                     {
                         return names.Where(name => !name.StartsWith(variable)).ToList();
                     }
                     else if (condition.ToLower() == "endswith")
                     {
                         return names.Where(name => !name.EndsWith(variable)).ToList();
                     }
                     else if (condition.ToLower() == "length")
                     {
                         return names.Where(name => name.Length != int.Parse(variable)).ToList();
                     }
                     else
                     {
                         return names;
                     }
                 };

                Func<List<string>, string, string, List<string>> doubleWithCondition = (names, condition, variable) =>
               {
                   Func<List<string>, List<string>> doubleGuest = (namesList) =>
                   {
                       List<string> currentNames = namesList;

                       int namesCount = currentNames.Count;
                       int counter = 0;

                       if (condition.ToLower() == "length")
                       {
                           int lengthTarget = int.Parse(variable);

                           while (counter < namesCount && namesCount > 0)
                           {
                               if (currentNames[counter].Length == lengthTarget)
                               {
                                   currentNames.Insert(counter, currentNames[counter]);
                                   counter += 2;
                                   namesCount = currentNames.Count;
                               }
                               else
                               {
                                   counter++;
                               }
                           }

                           counter = 0;
                           namesCount = currentNames.Count;

                           return currentNames;
                       }
                       else
                       {
                           while (counter < namesCount && namesCount > 0)
                           {
                               currentNames.Insert(counter, currentNames[counter]);
                               counter += 2;
                               namesCount = currentNames.Count;
                           }

                           return currentNames;
                       }
                   };

                   if (condition.ToLower() == "length")
                   {
                       return doubleGuest(names);
                   }
                   else if (condition.ToLower() == "startswith")
                   {
                       return doubleGuest(names.Where(name => name.StartsWith(variable)).ToList());
                   }
                   else if (condition.ToLower() == "endswith")
                   {
                       return doubleGuest(names.Where(name => name.EndsWith(variable)).ToList());
                   }
                   else
                   {
                       return null;
                   }
               };

                if (action.ToLower() == "remove")
                {
                    names = removeWithCondition(names, condition, variable);
                }
                else if (action.ToLower() == "double")
                {
                    names = doubleWithCondition(names, condition, variable);
                }


                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
