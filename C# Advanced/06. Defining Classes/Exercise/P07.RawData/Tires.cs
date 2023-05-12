using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.RawData
{
    internal class Tires
    {
        public Tires(double pressure, int age) 
        { 
            Age = age; 
            Pressure = pressure; 
        }
        private int age;
        private double pressure;

        public int Age
        { 
            get { return age; } 
            set { this.age = value; }
        }
        public double Pressure
        {
            get { return pressure; }
            set { this.pressure = value; }
        }
    }
}
