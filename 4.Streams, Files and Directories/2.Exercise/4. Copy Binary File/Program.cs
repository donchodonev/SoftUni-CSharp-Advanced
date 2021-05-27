using System;
using System.IO;

namespace _4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"resources\copyMe.png";

            using (FileStream myfile = new FileStream(sourcePath, FileMode.Open))
            {
                //regardless of path, copied file will be in the folder of original file
                //copied file will have a name of "CopyOf{original file's name plus file extension}"

                string originalFileFolder = myfile.Name.Substring(0, myfile.Name.LastIndexOf('\\') + 1);
                string originalFileName = myfile.Name.Substring(myfile.Name.LastIndexOf('\\') + 1);

                using (FileStream newFile = new FileStream($"{originalFileFolder}\\CopyOf{originalFileName}",FileMode.Create))
                {
                    //too easy
                    // myfile.CopyTo(newFile);

                    byte[] buffer = new byte[1000];

                    while (newFile.Length < myfile.Length)
                    {
                        myfile.Read(buffer, 0, buffer.Length);

                        newFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
