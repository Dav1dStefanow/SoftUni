using System;
using System.Collections.Generic;

namespace P01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string ,string> names = new Dictionary<string ,string>();
            for(int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                if(!names.ContainsKey(name))
                {
                    names[name] = name;
                }
            }
            foreach(var name in names)
            {
                Console.WriteLine(name.Value);
            }
        }
    }
}
