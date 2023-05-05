using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SymbolInMatrix
{

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for(int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for(int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            bool doesContain = false;
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        doesContain = true;
                        goto LoopEnd;
                       
                    }
                }
            }
            LoopEnd:
            if(!doesContain)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}