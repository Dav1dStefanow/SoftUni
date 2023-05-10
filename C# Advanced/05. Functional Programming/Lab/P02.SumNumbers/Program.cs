using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> nums = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
           Count(nums);
           Sum(nums);
        }
        static void Sum(List<int> nums)
        {
            int sum = 0;
            foreach(int i in nums) 
            { 
                sum += i;
            }
            Console.WriteLine(sum);
        }
        static void Count(List<int> nums)
        {
            int count = 0;
            Stack<int > stack = new Stack<int>();
            foreach(int i in nums)
            {
                stack.Push(i);
            }
            for(int i = 0; i < nums.Count; i++)
            {
                stack.Pop();
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
