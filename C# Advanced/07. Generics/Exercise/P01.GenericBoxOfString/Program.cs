using System;

namespace P01.GenericBoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for(int i  = 0; i < numberOfStrings; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);  
            }
            Console.WriteLine(box);

           
        }
    }
}
