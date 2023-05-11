using System;
using System.Linq;

namespace P01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] name = Console.ReadLine().Split(' ');
            foreach(string s in name)
            {
                Console.WriteLine(s);
            }
        }
    }
}
