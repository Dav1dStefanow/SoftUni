using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace BalancedParenthesis
{

    class Program
    {
        static void Main(string[] args)
        {
            string exprecion = Console.ReadLine();
            Stack<char> openParenthesis = new Stack<char>();
            bool isBalanced = true;

            foreach (char c in exprecion)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    openParenthesis.Push(c);
                }
                else
                {
                    if (!openParenthesis.Any())
                    {
                        isBalanced = false;
                        break;
                    }

                    char currentOpenParenthesis = openParenthesis.Pop();

                    bool isRoundBalanced = currentOpenParenthesis == '(' && c == ')';
                    bool isCurlyBalanced = currentOpenParenthesis == '{' && c == '}';
                    bool isSquareBalanced = currentOpenParenthesis == '[' && c == ']';

                    if (isRoundBalanced == false &&
                        isSquareBalanced == false &&
                        isCurlyBalanced == false)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if(isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}