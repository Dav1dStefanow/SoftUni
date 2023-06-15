using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity)
        {
            this.fuelQuantity = fuel;
            this.littersPerKm = fuelConsumption + 1.4;
            this.tankCapacity = tankCapacity;
        }
        public void DriveEmpty()
        {
            this.littersPerKm -= 1.4;
        }
    }
}
