using System;
using System.Collections.Generic;

namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for(int i = 0; i < n; i++)
            {
                string[] colorClothes = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string color = colorClothes[0];
                if(!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }
                string[] others = colorClothes[1].Split(",");
                for(int o = 0; o < others.Length;o++)
                {
                    string currArticule = others[o];
                    if (!clothes[color].ContainsKey(currArticule))
                    {
                        clothes[color].Add(currArticule, 0);
                    }
                    clothes[color][currArticule]++;
                }
            }
            string[] wantedItem = Console.ReadLine().Split(" ");
            string itemColor = wantedItem[0];
            string currItem = wantedItem[1];
            foreach(var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                if (color.Key == itemColor )
                {
                    foreach (var clothing in color.Value)
                    {
                        if(clothing.Key == currItem)
                        {
                            Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                        }
                       
                    }
                }
                else
                {
                    foreach (var clothing in color.Value)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }
                }
              
            }
        }
    }
}
