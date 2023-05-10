using System;
using System.Text.RegularExpressions;

namespace P03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string list = Console.ReadLine();
            Regex pattern = new Regex(@"[A-Z][a-z]*");
            Action<string, Regex> func = PrintUpperCaseWords;
            func(list,pattern);
        }
        static void PrintUpperCaseWords(string list, Regex pattern)
        {
            MatchCollection match = pattern.Matches(list);
            foreach (Match m in match)
            {
                Console.WriteLine(m);
            }
        }
    }
}
