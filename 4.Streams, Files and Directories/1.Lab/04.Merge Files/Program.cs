using System;
using System.IO;

namespace _04.Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader firstFile = new StreamReader("resources\\FileOne.txt");
            StreamReader secondFile = new StreamReader("resources\\FileTwo.txt");
            StreamWriter thirdFile = new StreamWriter("resources\\output.txt");

            string third = string.Empty;

            using (firstFile)
            {
                using (secondFile)
                {
                    string first = firstFile.ReadLine();
                    string second = secondFile.ReadLine();

                    while (first != null || second != null)
                    {
                        third += first;
                        third += "\n";
                        third += second;
                        third += "\n";

                        first = firstFile.ReadLine();
                        second = secondFile.ReadLine();
                    }
                }
            }

            using (thirdFile)
            {
                thirdFile.WriteLine(third);
            }
        }
    }
}
