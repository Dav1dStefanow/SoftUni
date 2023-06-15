using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity)
        {
            this.fuelQuantity = fuel;
            this.littersPerKm = fuelConsumption + 0.9;
            this.tankCapacity = tankCapacity;
        }
    }
}
