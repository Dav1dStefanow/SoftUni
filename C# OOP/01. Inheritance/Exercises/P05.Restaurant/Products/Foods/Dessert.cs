using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Restaurant.Products.Foods
{
    internal class Dessert : Food
    {
        public Dessert(string name, decimal price, double calories) : base(name, price)
        {
            Calories = calories;
        }
        private double calories;
        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Name: {this.Name} , Price: {this.Price}, Grams: {this.Grams}, Calories: {this.Calories}";
        }
    }
}
