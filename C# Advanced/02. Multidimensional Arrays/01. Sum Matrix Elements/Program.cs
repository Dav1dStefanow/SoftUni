using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SumMatrixElements
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = nums[0];
            int cols = nums[1];
            int[,] matrix = new int[rows, cols];
            for(int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++) 
                {
                    matrix[row,col] = line[col];
                }
            }
            int sum = 0;
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            foreach(int m in matrix)
            {
               sum += m;
            }
            Console.WriteLine(sum);
        }
    }
}