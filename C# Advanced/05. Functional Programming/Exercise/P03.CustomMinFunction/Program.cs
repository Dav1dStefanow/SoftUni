using System;
using System.Linq;

namespace P03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int smallest = nums[0];
            foreach(int i in nums)
            {
                if(smallest >= i) smallest = i;
            }
            Console.WriteLine(smallest);
        }
    }
}
