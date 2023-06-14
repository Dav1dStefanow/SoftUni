using System;

namespace P01.MathOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MAthOperations mo = new MAthOperations();
            Console.WriteLine(mo.Add(2, 3));
            Console.WriteLine(mo.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));
        }
    }
}
