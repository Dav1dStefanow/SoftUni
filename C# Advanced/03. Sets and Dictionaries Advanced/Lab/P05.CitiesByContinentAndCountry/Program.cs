using System;
using System.Collections.Generic;

namespace P05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cities = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> ccc = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < cities; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string contry = input[1];
                string city = input[2];

                if (!ccc.ContainsKey(continent))
                {
                    ccc.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!ccc[continent].ContainsKey(contry))
                {
                    ccc[continent].Add(contry, new List<string>());
                }
                ccc[continent][contry].Add(city);
            }

            foreach (var continent in ccc)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var contry in continent.Value)
                {
                    Console.WriteLine($"  {contry.Key} -> {string.Join(", ", contry.Value)}");
                }
            }
        }
    }
}
