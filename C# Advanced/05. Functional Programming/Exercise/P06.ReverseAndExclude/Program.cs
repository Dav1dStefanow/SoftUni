using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % n == 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
