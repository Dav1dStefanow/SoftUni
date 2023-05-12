using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.RawData
{
    internal class Cargo
    {
        public Cargo(double weight, string type) 
        {
            Type = type;
            Weight = weight;
        }
        private string type;
        private double weight;

        public string Type
        { 
            get { return type; }
            set { type = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
