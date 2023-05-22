using System;
using System.Linq;

namespace P01.ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            ListyIterator<string> iterator = null;
            while((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split();
                if (tokens[0] == "Create")
                {
                    iterator = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (tokens[0] == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }
                else if (tokens[0] == "Print")
                {
                    iterator.Print();
                }
            }
        }
    }
}
