using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity)
        {
            this.fuelQuantity = fuel;
            this.littersPerKm = fuelConsumption + 1.6;
            this.tankCapacity = tankCapacity;
        }
        public override double LittersPerKm => this.littersPerKm;
        public override void Refuel(double litters)
        {
            if (litters < 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.tankCapacity >= this.fuelQuantity + litters)
            {
                this.fuelQuantity += litters * 0.95;
            }
            else if (this.tankCapacity < this.fuelQuantity + litters)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
            }
        }
    }
}
