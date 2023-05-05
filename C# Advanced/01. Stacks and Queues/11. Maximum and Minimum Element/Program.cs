using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace MaxMinElement
{

    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());
            Stack<int> nums = new Stack<int>();
            for(int i =0; i < queries; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    nums.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    nums.Pop();
                }
                else if(input[0] == 3)
                {
                    
                    int biggestNumInQuerie = nums.Peek();
                    foreach (int n in nums)
                    {
                        if (biggestNumInQuerie < n)
                        {
                            biggestNumInQuerie = n;
                        }
                    }
                    Console.WriteLine(biggestNumInQuerie);
                }
                else if(input[0] == 4)
                {
                    int smallestNumInQuerie = nums.Peek();
                    foreach(int n in nums)
                    {
                        if(smallestNumInQuerie > n)
                        {
                            smallestNumInQuerie = n;
                        }
                    }
                    Console.WriteLine(smallestNumInQuerie);
                }
            }
            Console.WriteLine(string.Join(", ",nums));
        }
    }
}