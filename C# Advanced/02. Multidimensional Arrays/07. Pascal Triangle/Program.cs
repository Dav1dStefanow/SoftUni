using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace PascalTriangle
{

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][]; 
            for(int i = 0; i < n; i++)
            {
                pascal[i] = new long[i + 1];
                pascal[i][0] = 1;
                pascal[i][pascal[i].Length - 1] = 1;
                for (int r = 1; r < pascal[i].Length - 1; r++)
                {
                    pascal[i][r] = pascal[i - 1][r - 1] + pascal[i - 1][r];
                }
            }
            for (int i = 0; i < n; i++) 
            {
                Console.WriteLine(string.Join(" ", pascal[i]));
            }
        }
    }
}