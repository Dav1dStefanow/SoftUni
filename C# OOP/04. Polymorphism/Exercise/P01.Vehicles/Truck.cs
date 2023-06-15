using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double fuelConsumption) 
            : base(fuel, fuelConsumption)
        {
            this.fuelQuantity = fuel;
            this.littersPerKm = fuelConsumption + 1.6;
        }
        public override double LittersPerKm => this.littersPerKm;
        public override double Refuel(double litters)
        {
            return this.fuelQuantity += litters * 0.95;
        }

    }
}
