using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Restaurant.Products.Beverages
{
    internal class Beverage : Product
    {
        
        private double milliliters;
        public double Milliliters 
        { 
            get { return milliliters; } 
            set { milliliters = value; } 
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Name: {this.Name} , Price: {this.Price}, Milliliteres: {this.Milliliters}";
        }
    }
}
