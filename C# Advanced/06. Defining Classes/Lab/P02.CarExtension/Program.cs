using System;

namespace P02.CarExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            Car car = new Car(carData[0], carData[1], int.Parse(carData[2]), double.Parse(carData[3]), double.Parse(carData[4]));
            double distance = double.Parse(Console.ReadLine());
            car.Drive(distance);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
