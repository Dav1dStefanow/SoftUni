using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Drawing;

namespace JaggedArrManipulator
{

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[n][];
            for (int row = 0; row < n; row++)
            {
                jaggedMatrix[row] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }
            for (int row = 0; row < jaggedMatrix.Length - 1; row++)
            {
                if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                {
                    jaggedMatrix[row] = jaggedMatrix[row].Select(x => x * 2).ToArray();
                    jaggedMatrix[row + 1] = jaggedMatrix[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    for (int curRow = 0; curRow < jaggedMatrix[row].Length; curRow++)
                    {
                        jaggedMatrix[row][curRow] /= 2;

                    }
                    for (int curRow = 0; curRow < jaggedMatrix[row + 1].Length; curRow++)
                    {
                        jaggedMatrix[row + 1][curRow] /= 2;

                    }
                }
            }

            string[] commandArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (commandArr[0].ToLower() != "end")
            {
                string cmdType = commandArr[0];
                int row = int.Parse(commandArr[1]);
                int col = int.Parse(commandArr[2]);
                int value = int.Parse(commandArr[3]);

                if (row < 0 || row >= jaggedMatrix.Length ||
                    col < 0 || col >= jaggedMatrix[row].Length)
                {
                    commandArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (cmdType.ToLower() == "add")
                {
                    jaggedMatrix[row][col] += value;
                }
                else if (cmdType.ToLower() == "subtract")
                {
                    jaggedMatrix[row][col] -= value;
                }

                commandArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < n; row++)
            {
                for (int i = 0; i < jaggedMatrix[row].Length; i++)
                {
                    Console.Write(jaggedMatrix[row][i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}