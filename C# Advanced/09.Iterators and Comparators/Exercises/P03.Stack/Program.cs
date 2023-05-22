using System;
using System.Linq;

namespace P03.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            MyStack<string> stack = new MyStack<string>();
            while((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Push")
                {
                    stack.Push(tokens.Skip(1).Select(el => el.Split(",").First()).ToArray());
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {

                        Console.WriteLine(ae.Message);
                    }
                }
            }
            foreach(string token in stack)
            {
                Console.WriteLine(token);
            }
            foreach (string token in stack)
            {
                Console.WriteLine(token);
            }
        }
    }
}
