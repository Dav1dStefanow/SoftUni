using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.VehiclesExtension
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuel, double fuelConsumption, double tankCapacity)
        {
            this.fuelQuantity = fuel;
            this.littersPerKm = fuelConsumption;
            this.tankCapacity = tankCapacity;
        }
        protected double fuelQuantity;
        protected double littersPerKm;
        protected double tankCapacity;
        public virtual double FuelQuantity => this.fuelQuantity;
        public virtual double LittersPerKm => this.littersPerKm;
        public virtual double TankCapacity => this.tankCapacity;
        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.tankCapacity >= this.fuelQuantity + litters)
            {
                this.fuelQuantity += litters;
            }
            else if(this.tankCapacity < this.fuelQuantity + litters)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
            }
            
        }
        public virtual void Drive(double kilometers)
        {
            if ((this.fuelQuantity / this.littersPerKm) < kilometers)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
            else if ((this.fuelQuantity / this.littersPerKm) > kilometers)
            {
                double consuption = kilometers * this.littersPerKm;
                this.fuelQuantity = this.fuelQuantity - consuption;
                Console.WriteLine($"{GetType().Name} travelled {kilometers} km");
            }
        }
    }
}
