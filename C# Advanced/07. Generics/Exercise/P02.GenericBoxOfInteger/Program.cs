using System;

namespace P02.GenericBoxOfInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < numberOfStrings; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Add(input);
            }
            Console.WriteLine(box);
        }
    }
}
