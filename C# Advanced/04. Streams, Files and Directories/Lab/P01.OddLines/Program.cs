using System;
using System.IO;

namespace P01.OddLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = @"D:\SoftUniStreams\intput.txt";
            string output = @"D:\SoftUniStreams\output.txt";
            ExtractOddLines(input, output);
        }
        static void ExtractOddLines(string input,string output)
        {
            using StreamReader sr = new StreamReader(input);
            using StreamWriter sw = new StreamWriter(output);
            int rowNumber = 1;
            while(!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if(rowNumber % 2 == 0)
                {
                    sw.WriteLine(line);
                }
                rowNumber++;
            }

        }
    }
}
