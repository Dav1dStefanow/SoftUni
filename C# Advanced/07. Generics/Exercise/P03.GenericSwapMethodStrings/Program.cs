using System;
using System.Linq;

namespace P03.GenericSwapMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < numberOfStrings; i++)
            {
                string input = Console.ReadLine();
               
                box.Add(input);
            }
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(nums[0], nums[1]);
            Console.WriteLine(box);
        }
    }
}
