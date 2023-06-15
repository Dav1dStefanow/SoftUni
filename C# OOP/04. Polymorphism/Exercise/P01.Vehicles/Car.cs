using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuel, double fuelConsumption) 
            : base(fuel, fuelConsumption)
        {
            this.fuelQuantity = fuel;
            this.littersPerKm = fuelConsumption + 0.9;    
        }
        public override double LittersPerKm => this.littersPerKm;
    }
}
