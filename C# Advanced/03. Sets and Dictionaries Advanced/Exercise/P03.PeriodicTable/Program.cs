using System;
using System.Collections.Generic;

namespace P03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int n = int.Parse(Console.ReadLine());
          SortedDictionary<string, string> parts = new SortedDictionary<string, string>();
            for(int i =0 ; i < n; i++)
            {
                string[] Ps = Console.ReadLine().Split();
                for(int r = 0; r < Ps.Length; r++)
                {
                    if (!parts.ContainsKey(Ps[r]))
                    {
                        parts.Add(Ps[r], Ps[r]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ",parts.Keys));
        }
    }
}
