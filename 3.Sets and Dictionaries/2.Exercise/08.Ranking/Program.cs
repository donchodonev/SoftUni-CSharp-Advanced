using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> ranking = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> contest = new Dictionary<string, string>();

            //outter key is username
            //outter value is inner dictionary

            //inner key is course
            //inner value is course points

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] inputArgs = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string nameOfContest = inputArgs[0];
                string passOfContest = inputArgs[1];

                contest.TryAdd(nameOfContest, passOfContest);

                input = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "end of submissions")
            {
                string[] inputArgs = secondInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string nameOfContest = inputArgs[0];
                string passOfContest = inputArgs[1];
                string username = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (contest.ContainsKey(nameOfContest))
                {
                    if (contest[nameOfContest] == passOfContest)
                    {
                        if (ranking.ContainsKey(username))
                        {
                            if (ranking[username].ContainsKey(nameOfContest))
                            {
                                if (ranking[username][nameOfContest] < points)
                                {
                                    ranking[username][nameOfContest] = points;
                                }
                            }
                            else
                            {
                                ranking[username].Add(nameOfContest, points);
                            }
                        }
                        else
                        {
                            ranking.Add(username, new Dictionary<string, int>());
                            ranking[username].Add(nameOfContest, points);
                        }
                    }
                }

                secondInput = Console.ReadLine();

            }

            string nameOfBest = ranking.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
            int pointsOfBest = ranking[nameOfBest].Values.Sum();

            Console.WriteLine($"Best candidate is {nameOfBest} with total {pointsOfBest} points.");
            Console.WriteLine("Ranking: ");

            foreach (var user in ranking.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");

                foreach (var contests in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contests.Key} -> {contests.Value}");
                }
            }
        }
    }
}
