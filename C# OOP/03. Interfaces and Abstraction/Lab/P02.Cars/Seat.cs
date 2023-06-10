using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P02.Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color) 
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get ; set ; }
        public string Color { get ; set ; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
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
