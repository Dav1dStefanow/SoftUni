using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace P03.WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"D:\SoftUniStreams\intput.txt");
            string output = @"D:\SoftUniStreams\output.txt";
            string[] words = File.ReadAllLines(@"D:\SoftUniStreams\words.txt");
            WordCouter(input, output, words);


        }
        static void WordCouter(string[] input, string output, string[] words)
        {
            using StreamWriter sw = new StreamWriter(output);
            Dictionary<string, int> matchingWs = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string pattern = @$"\b{word}";
                matchingWs.Add(word, 0);
                for (int i = 0; i < input.Length; i++)
                {
                    foreach (Match m in Regex.Matches(input[i].ToLower(), pattern))
                    {
                        matchingWs[word]++;
                    }
                }
            }

            foreach (var item in matchingWs.OrderByDescending(x => x.Value))
            {
                sw.WriteLine($"{item.Key} - {item.Value}");
            }

        }
    }
}
