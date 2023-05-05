using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace StackSum
{

    class Program
    {
        static void Main(string[] args)
        {
            string numsInString = Console.ReadLine();
            Stack<int> numbers = new Stack<int>();
            string[] numsArr = numsInString.Split();
            foreach(string i in numsArr)
            {
                numbers.Push(int.Parse(i));
            }
            string input = Console.ReadLine().ToLower();
            string[] command = input.Split();
            while(command[0] != "end")
            {
                if (command[0] == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if(command[0] == "remove")
                {
                    if (int.Parse(command[1]) < numbers.Count)
                    {
                        for(int i = 0; i < int.Parse(command[1]); i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                input = Console.ReadLine().ToLower();
                command = input.Split();
            }
           int sum = 0;
            foreach(int i in numbers)
            {
                sum += i;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}