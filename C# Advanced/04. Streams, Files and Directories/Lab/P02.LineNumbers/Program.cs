using System;
using System.IO;

namespace P02.LineNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = @"D:\SoftUniStreams\intput.txt";
            string output = @"D:\SoftUniStreams\output.txt";
            LineNumbers(input, output);
        }
        static void LineNumbers(string input, string output)
        {
            using StreamReader sr = new StreamReader(input);
            using StreamWriter sw = new StreamWriter(output);
            int rowNumber = 1;
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                sw.WriteLine($"{rowNumber}. {line}");
                rowNumber++;
            }
        }
    }
}
