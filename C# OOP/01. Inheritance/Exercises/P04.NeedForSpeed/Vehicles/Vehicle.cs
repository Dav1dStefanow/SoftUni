using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.NeedForSpeed.Vehicles
{
    abstract class Vehicle
    {
        public Vehicle(int horsePower, double fuel) 
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
        protected int horsePower;
        protected double fuel;
        protected double defaultFuelConsumption;
        protected double fuelConsumption;

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        public double DefaultFuelConsumption
        {
            get { return defaultFuelConsumption; }
            set { defaultFuelConsumption = value; }
        }
        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public virtual void Drive(double kilometers)
        {
            DefaultFuelConsumption = 1.25;
            double roadDriven = DefaultFuelConsumption * kilometers;
            Console.WriteLine(roadDriven);
        }
    }
}
