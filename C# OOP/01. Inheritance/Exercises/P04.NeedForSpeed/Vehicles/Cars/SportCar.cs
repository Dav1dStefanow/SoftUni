using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.NeedForSpeed.Vehicles.Car
{
    internal class SportCar : Car
    {
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
        public override void Drive(double kilometers)
        {
            DefaultFuelConsumption = 10;
            double roadDriven = DefaultFuelConsumption * kilometers;
            Console.WriteLine(roadDriven);
        }
    }
}
