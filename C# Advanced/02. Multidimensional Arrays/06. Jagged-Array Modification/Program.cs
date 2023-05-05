using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace JaggedArrModification
{

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] ints = new int[n][];
            for(int i = 0;i< n;i++)
            {
                ints[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();    
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                int currArr = int.Parse(command[1]);
                int currPosition = int.Parse(command[2]);
                int additionOrSubstraction = int.Parse(command[3]);
                if (command[0] == "Add")
                {
                    if(n - 1 >= currArr && currArr > -1  && ints[currArr].Length - 1 >= currPosition && currPosition > -1)
                    {
                        ints[currArr][currPosition] += additionOrSubstraction;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (command[0] == "Subtract")
                {
                    if (n - 1 >= currArr && currArr > -1 && ints[currArr].Length - 1 >= currPosition && currPosition > -1)
                    {
                        ints[currArr][currPosition] -= additionOrSubstraction;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                command = Console.ReadLine().Split();
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", ints[i]));
            }
        }
    }
}