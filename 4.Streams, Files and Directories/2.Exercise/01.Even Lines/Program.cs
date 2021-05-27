using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            //read all lines from the text file

            string[] text = File.ReadAllLines("resources\\text.txt");

            //define destination file

            string destination = "resources\\output.txt";

            //completely unneeded as FileAppendAllText() single-handedly opens FileStream
            //then writes the text
            //then calls Close() which in turn calls Flush() for the stream
            //but i like it

            File.Create(destination).Close(); 

            //replace punctuation marks with @

            for (int i = 0; i < text.Length; i++)
            {
                text[i] = Regex.Replace(text[i], @"[,.?!-]", "@");
            }

            string[] evenLinesText = new string[(text.Length / 2) + 1];

            //counter

            int evenLinesCounter = 0;

            //get only even line number lines from the modified text

            for (int i = 0; i < text.Length; i += 2, evenLinesCounter++)
            {
                evenLinesText[evenLinesCounter] = text[i];
            }

            //create a jagged array where the reversed sentences will be seeded to

            string[][] reversedSentences = new string[evenLinesText.Length][];

            //create regex so we can get all words, as we need the words' order reversed - not the words themselves !

            Regex words = new Regex(@"(?<word>[^ ]+)");

            //creater our jagged arrays' counter

            int sentenceCounter = 0;
            int wordCounter = 0;

            foreach (var sentence in evenLinesText)
            {
                //get all words from the sentences
                MatchCollection wordsMatch = words.Matches(sentence);

                //initialise inner array
                reversedSentences[sentenceCounter] = new string[wordsMatch.Count];

                //reverse the order of the words and save them
                //need for-loop as for-each is read-only

                for (int i = wordsMatch.Count - 1; i >= 0; i--)
                {
                    reversedSentences[sentenceCounter][wordCounter] = wordsMatch[i].Value;
                    wordCounter++;
                }

                //reset word counter
                wordCounter = 0;
                //switch to next sentence
                sentenceCounter++;
            }

            //write to the output file

            for (int row = 0; row < reversedSentences.Length; row++)
            {
                for (int col = 0; col < reversedSentences[row].Length; col++)
                {
                    File.AppendAllText(destination, $"{reversedSentences[row][col]} ");
                }

                File.AppendAllText(destination, "\n");
            }
        }
    }
}
