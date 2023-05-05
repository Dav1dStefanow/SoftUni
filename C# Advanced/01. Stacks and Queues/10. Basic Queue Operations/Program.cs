using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace BasicQueueOperations
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = nums[0];
            int numsToPop = nums[1];
            int numToLookFor = nums[2];
            Queue<int> stackOfNums = new Queue<int>();
            int[] numsAmmount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numsAmmount.Length; i++)
            {
                int newNum = numsAmmount[i];
                stackOfNums.Enqueue(newNum);
            }
            for (int i = 0; i < numsToPop; i++)
            {
                stackOfNums.Dequeue();
            }
            bool isNumToLookForIn = false;
            int smallestNumInStack;
            if (stackOfNums.Count == 0)
            {
                smallestNumInStack = 0;
            }
            else
            {
                smallestNumInStack = stackOfNums.Peek();
            }
            foreach (int num in stackOfNums)
            {
                if (num == numToLookFor)
                {
                    isNumToLookForIn = true;
                }
                if (smallestNumInStack > num)
                {
                    smallestNumInStack = num;
                }
            }
            if (isNumToLookForIn)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(smallestNumInStack);
            }
        }
    }
}