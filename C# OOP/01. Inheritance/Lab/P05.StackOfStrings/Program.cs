using System;
using System.Security.Cryptography.X509Certificates;

namespace P05.StackOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackOfString stack = new StackOfString();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Push("D");
            stack.Push("E");
            stack.Push("F");
            Console.WriteLine(stack.IsEmpty());
            StackOfString stack2 = new StackOfString();
            stack2.AddRange(stack);
        }
    }
}
