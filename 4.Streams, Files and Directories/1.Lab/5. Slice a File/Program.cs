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

            using (streamReadFile) //we open the source file
            {
                long pieceSize = (long)Math.Ceiling((double)streamReadFile.Length / parts); //define how large a quarter is

                for (int i = 0; i < parts; i++)
                {
                    //reset current piece's size as it's needed to track piece progress

                    long currentPieceSize = 0;

                    //create a new file

                    FileStream streamCreateFile = new FileStream($"{destinationDir}{files[i]}", FileMode.Create);

                    using (streamCreateFile)
                    {
                        byte[] buffer = new byte[4096]; //create an instance of the buffer holding bytes

                        //The read method reads buffer.Length amount of bytes and stores them in the buffer
                        //The write method takes the bytes and writes those to the current file

                        //basically an endless cycle
                        while (true)
                        {
                            streamReadFile.Read(buffer, 0, buffer.Length); //fill buffer
                            currentPieceSize += buffer.Length;//increase current piece size
                            streamCreateFile.Write(buffer, 0, buffer.Length);//take buffer info and send it to file

                            //make sure cycle ends when part size condition is met

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
