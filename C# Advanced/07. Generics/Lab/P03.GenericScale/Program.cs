using System;

namespace P03.GenericScale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] leftRight = Console.ReadLine().Split();
            string left = leftRight[0];
            string right = leftRight[1];
            Console.WriteLine(EqualityScale.AreEqual(left, right));
        }
    }
}
