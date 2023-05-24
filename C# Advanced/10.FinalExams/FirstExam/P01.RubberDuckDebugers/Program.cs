using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace P01.RubberDuckDebugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> ducks = new Dictionary<string, int>();
            ducks.Add("Darth Vader Ducky",0);
            ducks.Add("Thor Ducky", 0);
            ducks.Add("Big Blue Rubber Ducky", 0);
            ducks.Add("Small Yellow Rubber Ducky", 0);

            while(queue.Any() && stack.Any())
            {
                int currDucky = queue.Peek() * stack.Peek();
                if ((currDucky >= 0) && (currDucky <= 240))
                {
                    if (currDucky >= 0 && currDucky <= 60)
                    {
                        ducks["Darth Vader Ducky"]++;
                    }
                    else if (currDucky >= 61 && currDucky <= 120)
                    {
                        ducks["Thor Ducky"]++;
                    }
                    else if (currDucky >= 121 && currDucky <= 180)
                    {
                        ducks["Big Blue Rubber Ducky"]++;
                    }
                    else if (currDucky >= 181 && currDucky <= 240)
                    {
                        ducks["Small Yellow Rubber Ducky"]++;
                    }
                    queue.Dequeue();
                    stack.Pop();
                    continue;
                }
                else
                {
                    stack.Push(stack.Pop() - 2);
                    queue.Enqueue(queue.Dequeue());
                }
            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded: ");
            foreach (var duck in ducks)
            {
                Console.WriteLine($"{duck.Key}: {duck.Value}");
            }
        }
    }
}
