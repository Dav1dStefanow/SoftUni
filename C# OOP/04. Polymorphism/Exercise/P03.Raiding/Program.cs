using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wattiors = int.Parse(Console.ReadLine());
            List<BaseHero> list = new List<BaseHero>();
            for(int i = 0; i < wattiors; i++)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();
                if(heroType == "Paladin")
                {
                    Paladin pal = new Paladin(name);
                    list.Add(pal);
                }
                else if(heroType == "Warrior")
                {
                    Warrior war = new Warrior(name);
                    list.Add(war);
                }
                else if (heroType == "Rogue")
                {
                    Rogue rogue = new Rogue(name);
                    list.Add(rogue);
                }
                else if (heroType == "Druid")
                {
                    Druid druid = new Druid(name);
                    list.Add(druid);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            int sum = 0; list.ForEach(p => sum += p.Power);
            int bossPower = int.Parse(Console.ReadLine());
            if(bossPower <= sum)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
