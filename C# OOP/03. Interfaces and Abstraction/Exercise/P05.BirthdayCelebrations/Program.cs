using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P05.BirthdayCelebrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> list = new List<IBirthable>();
            string personInfo;
            while ((personInfo = Console.ReadLine()) != "End")
            {
                string[] values = personInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (values[0] == "Pet")
                {
                    Pet pet = new Pet(values[1], values[2]);
                    list.Add(pet);
                }
                else if (values[0] == "Citizen")
                {
                    Citizen person = new Citizen(values[1], int.Parse(values[2]), values[3], values[4]);
                    list.Add(person);
                }
            }
            string bdYear = Console.ReadLine();

            foreach(var p in list)
            {
                string[] bd = p.BirthDate.Split("/").ToArray();
                if (Regex.IsMatch(bd[2],bdYear))
                {
                    Console.WriteLine(p.BirthDate);
                }
            }
        }
    }
}
