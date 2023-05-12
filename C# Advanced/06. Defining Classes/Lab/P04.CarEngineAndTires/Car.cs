using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.CarEngineAndTires
{
    internal class Car
    {
        public Car(string manufacturer, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Engine = engine;
            Tires = tires;
        }
        private string manufacturer;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

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
        public Engine Engine
        {   
            get { return engine; }
            set { engine = value; }
        }
        public Tire[] Tires
        { 
            get { return tires; } 
            set {tires = value; }
        }

        public string CarData()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Manufacturer: {Manufacturer}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Year: {Year}");
            sb.AppendLine($"Fuel: {FuelQuantity}");
            sb.AppendLine($"HorsePower: {Engine.HorsePower}");
            sb.AppendLine($"Tires pressure: {Tires[0].Pressure}, {Tires[1].Pressure}, {Tires[2].Pressure}, {Tires[3].Pressure}");
            return sb.ToString().TrimEnd(); 
        }
    }
}
