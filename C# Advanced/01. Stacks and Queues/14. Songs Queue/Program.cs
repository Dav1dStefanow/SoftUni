using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace FastFood
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] songsInQueue = Console.ReadLine().Split(", ");
            Queue<string> playList = new Queue<string>();
            foreach(string s in songsInQueue) 
            {
                playList.Enqueue(s);
            }
            List<string> command = Console.ReadLine().Split().ToList();
            while(playList.Count != 0)
            {
                if (command[0] == "Play")
                {
                    playList.Dequeue();
                }
                else if(command[0] == "Add")
                {
                    command.RemoveAt(0);
                    string curSong = string.Join(" ", command);
                    if(playList.Contains(curSong))
                    {
                        Console.WriteLine($"{curSong} is already contained!");
                    }
                    else
                    {
                        playList.Enqueue(curSong);
                    }
                }
                else if(command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ",playList));
                }
                command = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine("No more songs!");
            
        }
    }
}