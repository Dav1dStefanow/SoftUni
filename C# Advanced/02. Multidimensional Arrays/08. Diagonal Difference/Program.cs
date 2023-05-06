using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace DiagonalDifference
{

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int r = 0; r < n; r++)
                {
                    matrix[i, r] = nums[r];
                }
            }
            int rightSum = 0;
            int leftSum = 0;
            for (int i = 0; i < n; i++)
            {
                rightSum += matrix[i, i];
            }
            int secondIndex = n - 1;
            for (int j = 0; j < n; j++)
            { 
                leftSum += matrix[j, secondIndex];
                secondIndex--;
            }
            int leftRigthDiff = Math.Abs(rightSum - leftSum);
            Console.WriteLine(leftRigthDiff);

        }
    }
}