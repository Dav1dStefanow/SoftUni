using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> dividedNums = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                bool isDididable = true;
                for(int r = 0; r < nums.Length; r++)
                {
                    if(i % nums[r] == 0)
                    {
                        isDididable = true;
                    }
                    else
                    {
                        isDididable = false;
                        break;
                    }
                }
                if (isDididable) Console.Write(i + " ");
            }
        }
    }
}
