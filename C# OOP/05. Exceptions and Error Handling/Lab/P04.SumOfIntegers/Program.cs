using System;

namespace P04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            int sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    sum += int.Parse(numbers[i]);
                    Console.WriteLine($"Element {numbers[i]} processed - current sum: {sum}");
                }
                catch (OverflowException) 
                {
                    Console.WriteLine($"The element {numbers[i]} is out of range!");
                    Console.WriteLine($"Element {numbers[i]} processed - current sum: {sum}");
                }
                catch (Exception)
                {
                    Console.WriteLine($"The element {numbers[i]} is in wrong format!");
                    Console.WriteLine($"Element {numbers[i]} processed - current sum: {sum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
