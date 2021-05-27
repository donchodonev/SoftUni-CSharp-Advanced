using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] textLines = File.ReadAllLines("resources\\text.txt");

            int punctuationsCounter = 0;
            int lettersCounter = 0;

            for (int sentences = 0; sentences < textLines.Length; sentences++)
            {
                for (int character = 0; character < textLines[sentences].Length; character++)
                {
                    if (char.IsPunctuation(textLines[sentences][character]))
                    {
                        punctuationsCounter++;
                    }
                    else if (char.IsLetter(textLines[sentences][character]))
                    {
                        lettersCounter++;
                    }
                }

                File.AppendAllText("resources\\output.txt",$"Line {sentences + 1}: {textLines[sentences]} ({lettersCounter})({punctuationsCounter}) \n");

                punctuationsCounter = 0;
                lettersCounter = 0;
            }
        }
    }
}
