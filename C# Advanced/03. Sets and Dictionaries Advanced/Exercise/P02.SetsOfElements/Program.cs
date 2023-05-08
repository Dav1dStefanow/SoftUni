using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> setOne = new List<int>();
            List<int> setTwo = new List<int>();

            for(int i = 0;i < lengths[0]; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                setOne.Add(currNum);
            }

            for (int r = 0; r < lengths[1]; r++)
            {
                int currNum = int.Parse(Console.ReadLine());

                setTwo.Add(currNum);
                
            }
            List<int> matching = new List<int>();
            foreach(var num in setOne)
            {
                foreach(var number in setTwo)
                {
                    if(num == number)
                    {
                        if(!matching.Contains(num))
                        {
                            matching.Add(num);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",matching));
        }
    }
}
