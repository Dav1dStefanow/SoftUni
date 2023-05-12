using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carModels = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for(int i = 0; i < carModels; i++)
            {
                string[] carData = Console.ReadLine().Split();
                Car car = new Car(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
                cars.Add(car);
            }
            string[] command = Console.ReadLine().Split();
            while(command[0] != "End")
            {
                string model = command[1];
                int kilometers = int.Parse(command[2]);
                if(command[0] == "Drive")
                {
                    foreach(var car in cars)
                    {
                        if(car.Model == model)
                        {
                            car.Drive(kilometers); 
                            break;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            foreach(var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelQuantity:F2} {car.DistanceDriven}");
            }
        }
    }
}
