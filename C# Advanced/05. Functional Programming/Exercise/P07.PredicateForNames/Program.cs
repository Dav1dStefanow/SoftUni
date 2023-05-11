using System;

namespace P07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            for(int i = 0;i< names.Length;i++)
            {
                if (names[i].Length <= nameLength)
                {
                    Console.WriteLine(names[i]);
                }
            }
        }
    }
}
