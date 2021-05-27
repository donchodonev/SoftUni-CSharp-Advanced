using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string currentDirectory = Directory.GetCurrentDirectory();

            Dictionary<string, Dictionary<string, decimal>> files = new Dictionary<string, Dictionary<string, decimal>>();

            Directory.GetFiles(currentDirectory);

            //get file name and size and desktop path

            foreach (var filePath in Directory.GetFiles(currentDirectory))
            {
                DirectoryInfo fileInfo = new DirectoryInfo(filePath);
                string fileExtension = fileInfo.Extension;
                string name = fileInfo.Name;
                decimal size = Math.Round(File.OpenRead(filePath).Length / 1024m, 3, MidpointRounding.AwayFromZero);
                //var root = fileInfo.Root;

                if (files.ContainsKey(fileExtension))
                {
                    files[fileExtension].Add(name, size);
                }
                else
                {
                    files.Add(fileExtension, new Dictionary<string, decimal> { { name, size } });
                }
            }

            string lastExtension = string.Empty;

            File.Delete($"{desktopPath}\\output.txt");

            foreach (var file in files
                .OrderByDescending(x => x.Value.Keys.Count())
                .ThenBy(x => x.Key))
            {
                if (lastExtension != file.Key)
                {
                    File.AppendAllText($"{desktopPath}\\output.txt", $"{file.Key}\n");
                }

                foreach (var fileStats in file.Value.OrderBy(x => x.Value))
                {
                    File.AppendAllText($"{desktopPath}\\output.txt", $" --{fileStats.Key} - {fileStats.Value}kb\n");
                }

                lastExtension = file.Key;
            }
        }
    }
}
