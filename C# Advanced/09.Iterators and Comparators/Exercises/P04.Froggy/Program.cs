using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake stones = new Lake(input);
            foreach(int rock in stones)
            {
                Console.WriteLine(rock);
            }
        }
    }
}
