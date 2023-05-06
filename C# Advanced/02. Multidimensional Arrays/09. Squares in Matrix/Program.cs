using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SquareInMatrix
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixVolume = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixVolume[0]; int cols = matrixVolume[1];
            char[,] matrix = new char[rows, cols];
            for(int row = 0; row < rows; row++)
            {
                char[] letters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = letters[col];
                }
            }
            int matchingSquares = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
              
                for(int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char currLetter = matrix[row,col];
                    if(currLetter == matrix[row,col + 1] && currLetter == matrix[row + 1, col]
                     && currLetter == matrix[row + 1, col + 1])
                    {
                        matchingSquares++;
                    }
                }
            }
            Console.WriteLine(matchingSquares);
        }
    }
}