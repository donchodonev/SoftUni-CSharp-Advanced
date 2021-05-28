using System;
using System.IO;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var rand = new Random(91268935);

            Console.WriteLine("This will delete exiting copyMe.zip file, do you want to continue ?");

            string input = Console.ReadLine();

            if (input.ToLower() =="y" || input.ToLower() == "yes")
            {
                File.Delete($"{desktopPath}\\copyMe.zip");
                ZipFile.CreateFromDirectory("resources", $"{desktopPath}\\copyMe.zip", CompressionLevel.Optimal, true);
            }
            else
            {
                ZipFile.CreateFromDirectory("resources", $"{desktopPath}\\copyMe{rand.Next()}.zip", CompressionLevel.Optimal, true);
            }
        }
    }
}
