using System;

namespace P02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] name = Console.ReadLine().Split(' ');
            foreach (string s in name)
            {
                Console.WriteLine("Sir " + s);
            }
        }
    }
}
