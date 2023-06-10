using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P02.Cars
{
    internal class Seat : ICar
    {
        public Seat(string model, string color) 
        {
            this.model = model;
            this.color = color;
        }
        private string model;
        public string color;
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

        public override string ToString()
        {
            return $"{this.color} {this.GetType().Name} {this.model}";
        }

        string ICar.Start()
        {
            return "Engine start";
        }

        string ICar.Stop()
        {
            return "Breaaak!";
        }
    }
}
