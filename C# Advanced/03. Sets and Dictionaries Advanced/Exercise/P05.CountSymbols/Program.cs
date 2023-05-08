using System;
using System.Collections.Generic;

namespace P05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            SortedDictionary<char, int> parts = new SortedDictionary<char, int>();
            for(int i = 0; i < sentence.Length; i++)
            {
                char c = sentence[i];
                if(!parts.ContainsKey(c))
                {
                    parts.Add(c, 0);
                }
                parts[c]++;
            }
            foreach(var c in parts)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
