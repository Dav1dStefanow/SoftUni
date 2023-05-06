using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MatrixShuffling
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
            string[] swapCommand = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while(swapCommand[0] != "END" )
            {

                if (swapCommand.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    swapCommand = Console.ReadLine().Split().ToArray();
                    continue;
                }

                string cmd = swapCommand[0];
                int row1 = int.Parse(swapCommand[1]);
                int col1 = int.Parse(swapCommand[2]);
                int row2 = int.Parse(swapCommand[3]);
                int col2 = int.Parse(swapCommand[4]);

                if (cmd != "swap" || (row1 < 0 || row1 >= matrix.GetLength(0))
                    || (col1 < 0 || col1 >= matrix.GetLength(1))
                    || (row2 < 0 || row2 >= matrix.GetLength(0))
                    || (col2 < 0 || col2 >= matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid input!");
                    swapCommand = Console.ReadLine().Split().ToArray();
                    continue;
                }
                int firstValue = matrix[int.Parse(swapCommand[1]), int.Parse(swapCommand[2])];
                int secondValue = matrix[int.Parse(swapCommand[3]), int.Parse(swapCommand[4])];
                matrix[int.Parse(swapCommand[3]), int.Parse(swapCommand[4])] = firstValue;
                matrix[int.Parse(swapCommand[1]), int.Parse(swapCommand[2])] = secondValue;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }

                swapCommand = Console.ReadLine().Split().ToArray();
            }
        }
    }
}