using System;

namespace P11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int lettersDigitCount = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            int lettersSum = 0;
            foreach(string name in names)
            {
                foreach(var l in name)
                {
                    lettersSum += l;
                }
                if(lettersSum >= lettersDigitCount)
                {
                    Console.WriteLine(name); 
                    break;
                }
                else
                {
                    lettersSum = 0;
                }
            }
        }
    }
}
