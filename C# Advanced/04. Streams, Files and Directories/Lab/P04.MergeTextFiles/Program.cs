using System;
using System.IO;

namespace P04.MergeTextFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = File.ReadAllLines(@"D:\SoftUniStreams\intput.txt");
            string[] line2 = File.ReadAllLines(@"D:\SoftUniStreams\words.txt");
            string result = @"D:\SoftUniStreams\output.txt";
            FilesMerge(line1, line2, result);
        }
        static void FilesMerge(string[] lines1, string[] lines2, string result)
        {
            using StreamWriter sw = new StreamWriter(result);
            int biggestLine = lines1.Length;
            if(lines2.Length > biggestLine) biggestLine = lines2.Length;
            for(int i = 0; i < biggestLine; i++)
            {
                if(lines1.Length > i)
                {
                    sw.WriteLine(lines1[i]);
                }
                if (lines2.Length > i)
                {
                    sw.WriteLine(lines2[i]);
                }
            }
        }
    }
}
