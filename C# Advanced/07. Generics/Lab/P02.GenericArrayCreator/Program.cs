using System;

namespace P02.GenericArrayCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Creator.Create(5, "Niki");
            Console.WriteLine(string.Join(" ",strings));
        }
    }
}
