using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string textSource = "resources\\text.txt";
            string wordsSource = "resources\\words.txt";

            string actualResultDest = "resources\\actualResult.txt";
            string expectedResultDest = "resources\\expectedResult.txt";

            string[] inputWords = File.ReadAllLines(wordsSource);

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] sentences = new string[File.ReadAllLines(textSource).Length];

            int counter = 0;

            //remove dash from the start of each sentence
            foreach (var line in File.ReadAllLines(textSource))
            {
                while (counter != inputWords.Length)
                {
                    var matches = Regex.Matches(line, @$"\b{inputWords[counter]}\b", RegexOptions.IgnoreCase);

                    foreach (Match match in matches)
                    {
                        if (wordsCount.ContainsKey(match.Value.ToLower()))
                        {
                            wordsCount[match.Value.ToLower()]+= matches.Count();
                            break;
                        }
                        else
                        {
                            wordsCount.Add(match.Value.ToLower(), matches.Count());
                            break;
                        }
                    }

                    counter++;
                }
                counter = 0;
            }

            File.Delete(actualResultDest);

            foreach (var word in wordsCount)
            {
                File.AppendAllText(actualResultDest,$"{word.Key} - {word.Value} \n");
            }

            File.Delete(expectedResultDest);

            foreach (var word in wordsCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(expectedResultDest, $"{word.Key} - {word.Value} \n");
            }
        }
    }
}
