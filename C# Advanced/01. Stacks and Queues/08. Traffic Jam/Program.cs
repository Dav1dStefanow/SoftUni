using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace TrafficJam
{

    class Program
    {
        static void Main(string[] args)
        {
            int passedCarsEachG = int.Parse(Console.ReadLine());
            string carOrLight = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int carPassed = 0;
            while (carOrLight != "end")
            {
                if(carOrLight == "green")
                {
                    for(int i = 0;i < passedCarsEachG;i++)
                    {
                        string currCar = cars.Dequeue();
                        Console.WriteLine($"{currCar} passed!");
                        carPassed++;
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        
                    }
                }
                else
                {
                    cars.Enqueue(carOrLight);
                }
                carOrLight = Console.ReadLine();
            }

            Console.WriteLine($"{carPassed} cars passed the crossroads.");  
        }
    }
}