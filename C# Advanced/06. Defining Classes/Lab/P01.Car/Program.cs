using System;

namespace P01.Car
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            Car car = new Car(carData[0], carData[1], int.Parse(carData[2]));

            Console.WriteLine($"Manufacturer: {car.Manufacturer}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Model: {car.Year}");
        }
        
    }
}
