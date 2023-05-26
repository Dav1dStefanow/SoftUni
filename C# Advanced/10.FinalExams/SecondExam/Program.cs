using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.
                RemoveEmptyEntries).Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.
                RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string,int> healingItems = new Dictionary<string,int>();
            healingItems.Add("MedKit", 0);
            healingItems.Add("Bandage", 0);
            healingItems.Add("Patch", 0);

            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int medicament = textiles.Peek() + medicaments.Peek();
                if (medicament == 100 || medicament == 110)
                {
                    if (medicament == 100)
                    {
                        
                        healingItems["MedKit"]++;
                        textiles.Dequeue();
                        medicaments.Pop();
                    }
                    else if(medicament == 110)
                    {
                        
                        healingItems["MedKit"]++;
                        textiles.Dequeue();
                        medicaments.Pop();
                        int a = medicaments.Pop();
                        medicaments.Push(10 + a);
                    }
                }
                else if (medicament == 30)
                {
                   
                    healingItems["Patch"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if(medicament == 40)
                {
                   
                    healingItems["Bandage"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else
                {
                    textiles.Dequeue();
                    int a =  medicaments.Pop();
                    medicaments.Push(10 + a);
                }
            }

            if (textiles.Count == 0 && medicaments.Count > 0)
            {
                Console.WriteLine("Textiles are empty.");
                foreach (var item in healingItems)
                {
                    if(item.Value == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
                Console.Write($"Medicaments left: " + string.Join(", ", medicaments));
            }
            else if (textiles.Count > 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
                foreach (var item in healingItems)
                {
                    if (item.Value == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
                Console.Write($"Textiles left: " + string.Join(", ", textiles));
            }
            else
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
                foreach (var item in healingItems)
                {
                    if (item.Value == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
