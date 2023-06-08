using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Restaurant.Products.Foods
{
    internal class Fish : MainDish
    {
        public Fish(string name, decimal price) : base(name, price)
        {
            this.Grams = grams;
        }
        private double grams = 22;
        public double Grams
        {
            get { return grams; } set
            {
                this.grams = value;
            }
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Name: {this.Name} , Price: {this.Price}, Grams: {this.Grams}";
        }
    }
}
