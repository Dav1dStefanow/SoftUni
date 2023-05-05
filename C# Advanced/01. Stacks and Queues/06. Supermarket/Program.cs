using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace SuperMarket
{

    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>();
            string nameOrCommand = Console.ReadLine();
            bool isAnyPaid = false;
            while (nameOrCommand != "End")
            {
                if(nameOrCommand == "Paid")
                {
                    isAnyPaid = true;
                }
                people.Enqueue(nameOrCommand);
                nameOrCommand = Console.ReadLine();
            }
            
            if(isAnyPaid)
            {
                while (people.Count > 0)
                {
                    if (people.Peek() != "Paid")
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine($"{people.Count - 1} people remaining.");
            }
            else
            {
                 Console.WriteLine($"{people.Count} people remaining.");
            }
        }
    }
}