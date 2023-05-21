using System;
using System.Collections.Generic;

namespace P05.GenericCountMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for(int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            string element = Console.ReadLine();
            int count = StringComparison.LargerElements(list, element);
            Console.WriteLine(count);
        }
    }
}
