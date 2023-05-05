using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace HotPotato
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] players = Console.ReadLine().Split();
            Queue<string> queue = new Queue<string>();
            foreach(string p in players)
            {
                queue.Enqueue(p);
            }
            int sequenceOfEliminated = int.Parse(Console.ReadLine());
            while(queue.Count != 1)
            {
                for (int i = 1;i <= sequenceOfEliminated;i++)
                {
                   string skippedPlayer = queue.Dequeue();
                    if(i != sequenceOfEliminated)
                    {
                        queue.Enqueue(skippedPlayer);
                    }
                    else
                    {
                        Console.WriteLine($"Removed {skippedPlayer}");
                    }
                    
                }
            }
            Console.WriteLine("Last is " + string.Join(" ",queue));

        }
    }
}