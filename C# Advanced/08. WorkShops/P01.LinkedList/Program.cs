using System;

namespace P01.LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddFirst(3);
            // 3
            Console.WriteLine(string.Join("-", list.ToArray()));
            list.AddFirst(2);
            // 2-3
            Console.WriteLine(string.Join("-", list.ToArray()));
            list.AddFirst(1);
            // 1-2-3
            Console.WriteLine(string.Join("-", list.ToArray()));
            list.AddLast(4);
            // 1-2-3-4
            Console.WriteLine(string.Join("-", list.ToArray()));
            list.AddLast(5);
            // 1-2-3-4-5
            Console.WriteLine(string.Join("-", list.ToArray()));
            list.AddFirst(0);
            // 0-1-2-3-4-5
            Console.WriteLine(string.Join("-", list.ToArray()));
            list.AddLast(100);
            // 0-1-2-3-4-5-100
            list.RemoveLast();
            // 0-1-2-3-4-5
            Console.WriteLine(string.Join("-", list.ToArray()));
            list.RemoveFirst();
            // 1-2-3-4-5
            Console.WriteLine(list.Count);
           Console.WriteLine(string.Join("-",list.ToArray()));
            list.ForEach(x => Console.WriteLine("--" + x));
        }
    }
}
