using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            double[] nums = Console.ReadLine().Split(" ",StringSplitOptions
                .RemoveEmptyEntries).Select(double.Parse).ToArray();
            foreach(double num in nums)
            {
                if(!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }

                numbers[num]++;
            }
            foreach(var num in numbers)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}