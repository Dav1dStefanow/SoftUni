using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace FashionBoutique
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> pilesOfClothes = new Stack<int>();
            int rack = int.Parse(Console.ReadLine());
            foreach(int pile in clothes)
            {
                pilesOfClothes.Push(pile);
            }
            int racksNeeded = 0;
            int emptyRack = 0;
            foreach(int pile in pilesOfClothes)
            {
                if(emptyRack + pile > rack)
                {
                    emptyRack = 0;
                    racksNeeded++;
                    emptyRack += pile;
                }
                else
                {
                    emptyRack += pile;
                }  
            }
            Console.WriteLine(racksNeeded + 1);
        }
    }
}