using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Car
{
    internal class Car
    {
        public Car(string manufacturer,string model,int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }
        private string manufacturer;
        private string model;
        private int year;

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
    }
}
