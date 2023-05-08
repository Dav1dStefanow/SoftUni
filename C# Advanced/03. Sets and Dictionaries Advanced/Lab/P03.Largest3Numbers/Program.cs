using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sorted = numbers.OrderByDescending(x => x).ToArray();
            for (int i = 0; i < 3; i++) 
            { 
                if(i < sorted.Length)
                Console.Write(sorted[i] + " ");
                else
                {

                }
            }
        }
    }
}
