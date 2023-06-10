using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P02.Cars
{
    internal class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery) 
        {
            this.model = model;
            this.color = color;
            this.battery = battery;
        }

        private string model;
        private string color;
        private int battery;

        string ICar.Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        string ICar.Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        int IElectricCar.Battery
        { 
            get { return this.battery; }
            set { this.battery = value; }
        }

        string ICar.Start()
        {
            return "Engine start";
        }

        string ICar.Stop()
        {
            return ("Breaaak!");
        }
        public override string ToString()
        {
            return $"{this.color} {this.GetType().Name} {this.model}";
        }
    }
}
