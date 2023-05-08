using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> names = new Dictionary<string, List<decimal>>();
            for(int i = 0; i < n; i++)
            {
                string[] strudentData = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = strudentData[0];
                decimal grade = decimal.Parse(strudentData[1]);
                if(!names.ContainsKey(name))
                {
                    names.Add(name, new List<decimal>());
                    names[name].Add(grade);
                }
                else
                {
                    names[name].Add(grade);
                }
            }
            foreach(var name in names)
            {
                Console.Write($"{name.Key} -> ");
                for (int i = 0; i < name.Value.Count; i++)
                {
                    Console.Write($"{name.Value[i]:F2} ");
                } 
                Console.WriteLine($"(avg: {name.Value.Average():F2})");
            }
        }
       
    }
}
