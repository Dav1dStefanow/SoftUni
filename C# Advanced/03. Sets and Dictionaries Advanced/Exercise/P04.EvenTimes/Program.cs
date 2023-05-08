using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int , int> numbers = new Dictionary<int , int>();
            for(int i = 0; i < n; i++)
            {
                int currnum = int.Parse(Console.ReadLine());
                if(!numbers.ContainsKey(currnum))
                {
                    numbers[currnum] = 0;
                }
                numbers[currnum]++;
            }
            foreach(var num in numbers)
            {
                if(num.Value % 2 == 0)
                {
                    Console.Write(num.Key + " ");
                }
            }
        }
    }
}
