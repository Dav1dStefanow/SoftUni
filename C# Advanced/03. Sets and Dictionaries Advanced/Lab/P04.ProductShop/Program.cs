using System;
using System.Collections.Generic;

namespace P04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, decimal>> markets = 
                new SortedDictionary<string, Dictionary<string, decimal>>();
            string[] command = Console.ReadLine().Split(", ");
            while (command[0] != "Revision")
            {
                string market = command[0];
                string product = command[1];
                decimal price = Convert.ToDecimal(command[2]);
                if(!markets.ContainsKey(market))
                {
                    markets.Add(market, new Dictionary<string, decimal>());
                    markets[market].Add(product, price);
                }
                else if (!markets[market].ContainsKey(product))
                {
                    markets[market].Add(product, price);
                }
                command = Console.ReadLine().Split(", ");
            }
            foreach(var market in markets)
            {
                Console.WriteLine($"{market.Key}->");
                foreach(var product in market.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
