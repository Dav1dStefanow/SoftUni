using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.SpecialCars
{
    internal class Tires
    {
        public Tires(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }
        private int year;
        private double pressure;

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }
    }
}
