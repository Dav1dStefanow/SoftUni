using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Restaurant.Products.Foods
{
    internal class Food : Product
    {
        public Food(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        private double grams;

        public double Grams
        {
            get { return grams; }
            set { grams = value; }
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Name: {this.Name} , Price: {this.Price}, Grams: {this.Grams}";
        }
    }
}


