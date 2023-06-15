using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuel, double fuelConsumption) 
        {
            this.fuelQuantity = fuel;
            this.littersPerKm = fuelConsumption;
        }
        protected double fuelQuantity;
        protected double littersPerKm;
        public virtual double FuelQuantity => this.fuelQuantity;
        public virtual double LittersPerKm => this.littersPerKm;
        public virtual double Refuel(double litters)
        {
            return this.fuelQuantity += litters;
        }
        public virtual void Drive(double kilometers)
        {
            if((this.fuelQuantity / this.littersPerKm) < kilometers)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
            else if((this.fuelQuantity / this.littersPerKm) > kilometers)
            {
                double consuption = kilometers * this.littersPerKm;
                this.fuelQuantity = this.fuelQuantity - consuption;
                Console.WriteLine($"{GetType().Name} travelled {kilometers} km");
            }
        }
    } 
}
