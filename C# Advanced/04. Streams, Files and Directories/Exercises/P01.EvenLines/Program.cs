using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P01.EvenLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"D:\SoftUniStreams\input.txt";
            string pattern = @"[-,.!?]";

            using StreamReader streamReader = new StreamReader(fileName);

            string line = streamReader.ReadLine();
            int counter = 0;


            while (line != null)
            {
                if (counter % 2 == 0)
                {
                    foreach (Match m in Regex.Matches(line, pattern))
                    {
                        line = line.Replace(m.ToString(), "@");
                    }

                    string[] words = line.Split().ToArray();

                    Console.WriteLine(string.Join(" ", words.Reverse()));
                }

                counter++;
                line = streamReader.ReadLine();
            }
            

        }
    }
}
