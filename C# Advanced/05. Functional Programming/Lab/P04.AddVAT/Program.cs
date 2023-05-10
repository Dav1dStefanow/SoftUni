using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace P04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ").Select(double.Parse).ToArray();
            AddVat(prices);
            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine($"{prices[i]:F2}");
            }
        }
        static double[] AddVat(double[] prices)
        {
            for (int i = 0; i < prices.Length; i++)
            {
                prices[i] = prices[i] * 1.2;
            }
            return prices;
        }
    }
}
