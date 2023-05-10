using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Func<List<int>, List<int>> func = PrintEvenNums;
            var newList = PrintEvenNums(numbers);
            Console.WriteLine(string.Join(", ",newList));
        }
        static List<int> PrintEvenNums(List<int> numbers)
        {
            numbers = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
            var newList = numbers.ToList();
            return newList;
        }
        
    }
}
