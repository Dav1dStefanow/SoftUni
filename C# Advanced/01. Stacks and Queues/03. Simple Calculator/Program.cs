using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace SimpleCalculator
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] exercise = Console.ReadLine().Split();
            Stack<string> digitsChars = new Stack<string>();
            foreach (string s in exercise.Reverse())
            {
                digitsChars.Push(s);
            }
            int result = int.Parse(digitsChars.Pop());
            while(digitsChars.Count > 0)
            {
                string PlusMinus = digitsChars.Pop();
                int currDigit = int.Parse(digitsChars.Pop());
                if(PlusMinus == "+")
                {
                    result += currDigit;
                }
                else if(PlusMinus == "-")
                {
                    result -= currDigit;
                }
            }
            Console.WriteLine(result);
        }
    }
}