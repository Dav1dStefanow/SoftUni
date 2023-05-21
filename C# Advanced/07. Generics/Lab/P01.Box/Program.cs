using System;
using System.Runtime.CompilerServices;

namespace P01.Box
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            box.Add(4);
            box.Remove();
            Console.WriteLine(box.Count);
            Console.WriteLine(string.Join(" ",box.ToArray()));
        }
    }
}
