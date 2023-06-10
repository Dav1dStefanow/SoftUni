using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P02.Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery) 
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public int Battery { get; set; }
        

        public string Model { get ; set ; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString();
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
