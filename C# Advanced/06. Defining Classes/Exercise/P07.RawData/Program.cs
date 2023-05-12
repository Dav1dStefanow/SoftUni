using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

namespace P07.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for(int i = 0;i < carsCount; i++)
            {
                string[] currCarData = Console.ReadLine().Split();
                string model = currCarData[0];
                Engine engine = new Engine(int.Parse(currCarData[1]), int.Parse(currCarData[2]));
                Cargo cargo = new Cargo(double.Parse(currCarData[3]), currCarData[4]);
                Tires[] tires = new Tires[4];
                Tires tire1 = new Tires(double.Parse(currCarData[5]), int.Parse(currCarData[6]));
                Tires tire2 = new Tires(double.Parse(currCarData[7]), int.Parse(currCarData[8]));
                Tires tire3 = new Tires(double.Parse(currCarData[9]), int.Parse(currCarData[10]));
                Tires tire4 = new Tires(double.Parse(currCarData[11]), int.Parse(currCarData[12]));
                tires[0] = tire1; tires[1] = tire2; tires[2] = tire3; tires[3] = tire4;
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string cargoType = Console.ReadLine();
            if(cargoType == "fragile")
            {
                List<Car> validCars = new List<Car>();
                foreach(var car in cars)
                {
                    if(car.Cargo.Type == cargoType)
                    {
                        foreach (var tire in car.Tires)
                        {
                            if (tire.Pressure < 1)
                            {
                                
                                if(!validCars.Contains(car))
                                {
                                    validCars.Add(car);
                                }
                            }
                        }
                    }
                }
                foreach(var car in validCars)
                {
                    Console.WriteLine(car.Model);
                }

            }
            else if(cargoType == "flammable")
            {
                foreach (var car in cars)
                {
                    if(car.Engine.Power >= 250)
                    {
                        Console.WriteLine($"{car.Model}");
                        
                    }
                }
            }
        }
    }
}
