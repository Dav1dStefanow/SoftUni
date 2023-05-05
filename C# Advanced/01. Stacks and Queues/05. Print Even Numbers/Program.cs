using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace PrintEvenNums
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queueOfNums = new Queue<int>();
            for(int i = 0;i < nums.Length;i++) 
            {
                if (nums[i] % 2 == 0)
                {
                    queueOfNums.Enqueue(nums[i]);
                }
            }
            Console.WriteLine(string.Join(", ", queueOfNums));
        } 
    }
}