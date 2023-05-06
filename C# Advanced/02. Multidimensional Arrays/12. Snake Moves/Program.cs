using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SnakeMoves
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

            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = '\0';
                }
            }
            string snake = Console.ReadLine().Trim();
            int snakeSizeCounter = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (snakeSizeCounter == snake.Length)
                    {
                        snakeSizeCounter = 0;
                    }

                    if (row % 2 == 0)
                    {
                        matrix[row, col] = snake[snakeSizeCounter++];
                    }
                    else
                    {
                        matrix[row, matrix.GetLength(1) - 1 - col] = snake[snakeSizeCounter++];
                    }

                }

            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
