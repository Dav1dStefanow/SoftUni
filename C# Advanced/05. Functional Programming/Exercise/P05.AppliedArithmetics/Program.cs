using System;
using System.Linq;

namespace P05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while(command != "end")
            {
                if(command == "add")
                {
                    AddOne(numbers);
                }
                else if (command == "subtract")
                {
                    Subtract(numbers);
                }
                else if (command == "multiply")
                {
                    Multiply(numbers);
                }
                else if (command == "print")
                {
                    PrintArray(numbers);
                }
                command = Console.ReadLine();
            }
        }
        static int[] AddOne(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] += 1;
            }
            return numbers;
        }
        static int[] Multiply(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] *= 2;
            }
            return numbers;
        }
        static int[] Subtract(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] -= 1;
            }
            return numbers;
        }
        static void PrintArray(int[] numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
