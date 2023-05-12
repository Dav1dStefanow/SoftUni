using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.SpeedRacing
{
    internal class Car
    {
        public Car(string model, double fuelQuantity, double fuelConsumption) 
        { 
            Model = model;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        private string model;
        private double fuelQuantity;
        private double fuelConsumption;
        private double distanceDriven;

        public string Model
        { 
            get { return model; }
            set { model = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public double DistanceDriven
        { 
            get { return distanceDriven; }
            set { distanceDriven = value; }
        }
        public void Drive(int kilometers)
        {
            if(FuelQuantity - (FuelConsumption * kilometers) >= 0)
            {
                DistanceDriven += kilometers;
                FuelQuantity -= FuelConsumption * kilometers;

            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            
        }
    }
}
