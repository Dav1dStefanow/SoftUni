using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Restaurant.Products.Beverages
{
    internal class Coffee : HotBeverage
    {
        public Coffee(string name, double coffeine)
        {
            Name = name;
            Coffeine = coffeine;
        }
        private double coffeeMilliliters = 50;
        private decimal coffeePrice = 3.50M;
        private double caffeine;

        public double CoffeeMilliliteres
        {
            get { return coffeeMilliliters; }
            set { coffeeMilliliters = value; }
        }
        public decimal CoffeePrice
        {
            get { return coffeePrice; }
            set { coffeePrice = value; }
        }
        public double Coffeine
        {
            get { return caffeine; }
            set { caffeine = value; }
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Name: {this.Name} , Price: {this.CoffeePrice}, Milliliteres: {this.CoffeeMilliliteres}, Coffeine: {this.Coffeine}";
        }
    }
}
