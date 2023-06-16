using System;

namespace P01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            try
			{
                if(number < 1)
                {
                    throw new Exception();
                }
                double n = Math.Sqrt(number);
                Console.WriteLine(n);
            }
			catch (Exception)
			{
                Console.WriteLine("Invalid number");
            }
			finally 
			{
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
