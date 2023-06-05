using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.ShoeStore
{
    internal class Shoe
    {
        public Shoe(string brand, string type, double size, string material)
        { 
            Brand = brand;
            Type = type;
            Size = size;
            Material = material;
        }

        private string brand;
        private string type;
        private double size;
        private string material;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Type 
        {
            get { return type; }
            set { type = value; }
        }
        public double Size
        { 
            get { return size; } 
            set { this.size = value; } 
        }
        public string Material
        { 
            get { return material; } 
            set { material = value; }
        }

        public override string ToString()
        {
            return $"Size {Size}, {Material} {Brand} {Type} shoe.";
        }
    }
}
