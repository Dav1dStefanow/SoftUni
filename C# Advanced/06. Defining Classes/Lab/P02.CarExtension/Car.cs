using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace P02.CarExtension
{
    internal class Car
    {
        public Car(string manufacturer, string model, int year , double fuelQuantity, double fuelConsumption)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        private string manufacturer;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
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

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Manufacturer: {Manufacturer}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Year: {Year}");
            sb.AppendLine($"Fuel: {FuelQuantity}");
            return sb.ToString().TrimEnd();
        }
        public void Drive(double distance)
        {
            double carTank = FuelQuantity;
            double littersBurnedPerKilometers = FuelConsumption;
            if (carTank - littersBurnedPerKilometers * distance > 0)
             Console.WriteLine(carTank - littersBurnedPerKilometers * distance);
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
    }
}
