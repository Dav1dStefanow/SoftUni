using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.SpecialCars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<Tires[]> tires = new List<Tires[]>();
            int currTire = 0;
            while (command[0] != "No")
            {
                
                Tires[] currTires = new Tires[4];
                for (int i = 0; i < 8; i++)
                {
                    
                    Tires tire = new Tires(int.Parse(command[i]), double.Parse(command[i + 1]));
                    currTires[currTire] = tire;
                    currTire++;
                    if (currTire == 4) currTire = 0;
                    i++;
                }
                tires.Add(currTires);
                command = Console.ReadLine().Split();
            }

            string[] currEngineInfo = Console.ReadLine().Split();
            List<Engine> engines = new List<Engine>();
            while (currEngineInfo[0] != "Engines")
            {
                int horsePower = int.Parse(currEngineInfo[0]);
                double cubicCapacity = double.Parse(currEngineInfo[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
                currEngineInfo = Console.ReadLine().Split();
            }

            string[] carValidation = Console.ReadLine().Split();
            while (carValidation[0] != "Show")
            {
                Car car = new Car(carValidation[0], carValidation[1], int.Parse(carValidation[2])
                , double.Parse(carValidation[3]), double.Parse(carValidation[4]),
                engines[int.Parse(carValidation[5])], tires[int.Parse(carValidation[6])]);
                if(car.Year >= 2017 && car.Engine.HorsePower >= 300 )
                {
                    Console.WriteLine(car.ShowSpecial());
                }
                carValidation = Console.ReadLine().Split();
            }
        }
    }
}
