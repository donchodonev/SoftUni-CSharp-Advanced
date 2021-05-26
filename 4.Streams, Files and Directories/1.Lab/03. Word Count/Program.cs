using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader words = new StreamReader("resources\\words.txt");
            StreamReader text = new StreamReader("resources\\text.txt");
            StreamWriter repeatWords = new StreamWriter("resources\\output.txt");

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (words)
            {
                List<string> wordList = new List<string>();

                string line = words.ReadLine();

                while (line != null)
                {
                    wordList.Add(line);
                    line = words.ReadLine();
                }

                for (int i = 0; i < wordList.Count; i++)
                {
                    for (int v = 0; v < wordList[i].Split().Length; v++)
                    {
                        if (wordsCount.ContainsKey(wordList[i].Split()[v].ToLower()))
                        {
                            wordsCount[wordList[i].Split()[v].ToLower()]++;
                        }
                        else
                        {
                            wordsCount.Add(wordList[i].Split()[v].ToLower(), 0);
                        }
                    }
                }
            }


            using (text)
            {
                string currentLine = string.Empty;

                string line = text.ReadLine();

                while (line != null)
                {
                    currentLine = line.Substring(1);

                    string[] separators = { ",", " ", ", ", "." };

                    string[] currentWords = currentLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < currentWords.Length; i++)
                    {
                        if (wordsCount.ContainsKey(currentWords[i].ToLower()))
                        {
                            wordsCount[currentWords[i].ToLower()]++;
                        }
                    }

                    line = text.ReadLine();
                }
            }

            using (repeatWords)
            {
                foreach (var word in wordsCount.OrderByDescending(x => x.Value))
                {
                    repeatWords.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
