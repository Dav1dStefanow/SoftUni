using P04.NeedForSpeed.Vehicles.Car;
using P04.NeedForSpeed.Vehicles.Motorcycles;
using System;

namespace P04.NeedForSpeed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            car.Drive(120);
            RaceMotorcycle moto = new RaceMotorcycle(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            moto.Drive(120);
            SportCar sC = new SportCar(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            sC.Drive(120);
        }
    }
}
