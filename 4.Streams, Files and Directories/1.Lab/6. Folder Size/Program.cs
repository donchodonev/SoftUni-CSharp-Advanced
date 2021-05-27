using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] paths = Directory.GetFiles("TestFolder\\");

            double sizeSum = 0;

            foreach (var file in paths)
            {
                FileInfo fileInfo = new FileInfo(file);
                sizeSum += fileInfo.Length;
            }

            sizeSum = sizeSum / 1024 / 1024;

            File.WriteAllText("output.txt", sizeSum.ToString());

        }
    }
}
