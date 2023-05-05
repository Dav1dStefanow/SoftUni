using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace PrimaryDiagonal
{

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            int sumOfDiagonal = 0;
            for(int a = 0; a < n; a++)
            {
                sumOfDiagonal += matrix[a, a];
            }
            Console.WriteLine(sumOfDiagonal);
        }
    }
}