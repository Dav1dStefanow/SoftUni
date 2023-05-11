using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> numbersArr = new List<int>();
            for (int i = nums[0]; i <= nums[1];i++)
            {
                numbersArr.Add(i);
            }
            string OddOrEven = Console.ReadLine();

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 == 1;

            if (OddOrEven == "even")
            {
                List<int> evenNums = numbersArr.FindAll(isEven);
                Console.WriteLine(string.Join(" ",evenNums));
            }
            else
            {
                List<int> oddNums = numbersArr.FindAll(isOdd);
                Console.WriteLine(string.Join(" ", oddNums));
            }
           
            

        }
    }
}
