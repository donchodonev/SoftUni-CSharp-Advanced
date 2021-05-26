using System;
using System.IO;
using System.Collections.Generic;
namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "resources\\sliceMe.txt";
            string destinationDir = "resources\\";

            int parts = 4;

            List<string> files = new List<string>
            { 
                "Part-1.txt",
                "Part-2.txt",
                "Part-3.txt",
                "Part-4.txt"
            };

            FileStream streamReadFile = new FileStream(sourceFile, FileMode.Open);

            using (streamReadFile)
            {
                long pieceSize = (long)Math.Ceiling((double)streamReadFile.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    FileStream streamCreateFile = new FileStream($"{destinationDir}{files[i]}", FileMode.Create);

                    using (streamCreateFile)
                    {
                        byte[] buffer = new byte[4096];

                        while (streamReadFile.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            currentPieceSize += buffer.Length;
                            streamCreateFile.Write(buffer, 0, buffer.Length);

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
