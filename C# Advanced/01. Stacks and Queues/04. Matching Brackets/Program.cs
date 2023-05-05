using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace MatchingBrackets
{

    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> indices = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indices.Push(i);
                }
                else if (expression[i] == ')')
                {
                    var openBracketIndex = indices.Pop();
                    var closeBracketIndex = i;
                    Console.WriteLine(expression.Substring(openBracketIndex,closeBracketIndex - openBracketIndex + 1));
                }
                 

                
            }
        }
    }
}