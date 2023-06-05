using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> portion = new Stack<int>(Console.ReadLine()
            .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> stamina = new Queue<int>(Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> conqueredPeaks = new Dictionary<string, int>();
            conqueredPeaks.Add("Vihren", 0);
            conqueredPeaks.Add("Kutelo", 0);
            conqueredPeaks.Add("Banski Suhodol", 0);
            conqueredPeaks.Add("Polezhan", 0);
            conqueredPeaks.Add("Kamenitza", 0);

            bool areQoncuered = true;

            while (conqueredPeaks["Kamenitza"] != 1)
            {
                int currPortion = portion.Pop();
                int currStamina = stamina.Dequeue();

                if (conqueredPeaks["Vihren"] != 1)
                {
                    if(currStamina + currPortion >= 80) 
                    {
                        conqueredPeaks["Vihren"]++;
                    }
                    else
                    {
                        areQoncuered = false;
                        break;
                    }
                }
                else if (conqueredPeaks["Kutelo"] != 1)
                {
                    if (currStamina + currPortion >= 90)
                    {
                        conqueredPeaks["Kutelo"]++;
                    }
                    else
                    {
                        areQoncuered = false;
                        break;
                    }
                }
                else if (conqueredPeaks["Banski Suhodol"] != 1)
                {
                    if (currStamina + currPortion >= 100)
                    {
                        conqueredPeaks["Banski Suhodol"]++;
                    }
                    else
                    {
                        areQoncuered = false;
                        break;
                    }
                }
                else if (conqueredPeaks["Polezhan"] != 1)
                {
                    if (currStamina + currPortion >= 60)
                    {
                        conqueredPeaks["Polezhan"]++;
                    }
                    else
                    {
                        areQoncuered = false;
                        break;
                    }
                }
                else if (conqueredPeaks["Kamenitza"] != 1)
                {
                    if (currStamina + currPortion >= 70)
                    {
                        conqueredPeaks["Kamenitza"]++;
                    }
                    else
                    {
                        areQoncuered = false;
                        break;
                    }
                }

            }
           
            if(areQoncuered)

            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in conqueredPeaks)
                {
                    if (peak.Value == 1)
                    {
                        Console.WriteLine(peak.Key);
                    }
                }

            }
            else
            {
                if (conqueredPeaks["Vihren"] == 1)
                {
                    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                    Console.WriteLine("Conquered peaks:");
                    foreach (var peak in conqueredPeaks)
                    {
                        if (peak.Value == 1)
                        {
                            Console.WriteLine(peak.Key);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                }
            }
            Console.WriteLine();
        }
    }
}
