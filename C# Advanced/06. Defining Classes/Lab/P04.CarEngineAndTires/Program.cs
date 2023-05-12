using System;

namespace P04.CarEngineAndTires
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            string[] engineInfo = Console.ReadLine().Split();
            Engine engine = new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));
            Tire[] tires = new Tire[4];
            for(int i = 0 ; i < 4; i++)
            {
                string[] curTireInfo = Console.ReadLine().Split();
                Tire tire = new Tire(int.Parse(curTireInfo[0]), double.Parse(curTireInfo[1]));
                tires[i] = tire;
            }
            Car car = new Car(carData[0], carData[1], int.Parse(carData[2]), double.Parse(carData[3]), double.Parse(carData[4]), engine, tires);
            Console.WriteLine(car.CarData());
        }
    }
}
