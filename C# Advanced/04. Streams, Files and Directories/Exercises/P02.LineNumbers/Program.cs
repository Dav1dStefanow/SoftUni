using System;
using System.IO;
using System.Text.RegularExpressions;

namespace P02.LineNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = @"D:\SoftUniStreams\input.txt";
            string output = @"D:\SoftUniStreams\output.txt";
            string pattern = @"[-,.!?]";
            string patternn = @"[A-Za-z]";

            using StreamReader sr = new StreamReader(input);
            using StreamWriter sw = new StreamWriter(output);

            string line = sr.ReadLine();
            int counter = 1;
            while(line != null)
            {
                int punkMarks = 0;
                int lettersCount = 0;
                foreach (Match m in Regex.Matches(line, pattern))
                {
                    punkMarks++;
                }
                foreach (Match m in Regex.Matches(line, patternn))
                {
                    lettersCount++;
                }
                sw.WriteLine($"Line {counter}: {line} ({punkMarks}) ({lettersCount})");
                counter++;
                line = sr.ReadLine();
            }
        }
    }
}
