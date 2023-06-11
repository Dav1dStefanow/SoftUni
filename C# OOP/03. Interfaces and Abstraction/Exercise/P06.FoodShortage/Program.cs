using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.FoodShortage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cRS = int.Parse(Console.ReadLine());
            List<IBuyer> people = new List<IBuyer>();

            for (int i = 0; i < cRS; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if(tokens.Length == 4)
                {
                    Citizen person = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    people.Add(person);
                }
                else if(tokens.Length == 3)
                {
                    Rebel person = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    people.Add(person);
                }
            }
            string name;
            while((name = Console.ReadLine()) != "End")
            {
                foreach(var p in people)
                {
                    if(p.Name == name)
                    {
                        p.BuyFood();
                        break;
                    }
                }
            }
            int sum = 0;
            foreach(var p in people) 
            {
                sum += p.Food;
            }
            Console.WriteLine(sum);
        }
    }
}
