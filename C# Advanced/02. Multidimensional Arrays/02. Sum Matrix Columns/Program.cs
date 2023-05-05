using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SumMatrixColumns
{ 

    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = n[0];int cols = n[1];
            int[,] matrix = new int[rows, cols];
            for(int row = 0;row < rows;row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int colSum = 0;
                for (int row = 0; row < rows; row++)
                {
                    colSum += matrix[row, col];
                }
                Console.WriteLine(colSum);
            }

        }
    }
}