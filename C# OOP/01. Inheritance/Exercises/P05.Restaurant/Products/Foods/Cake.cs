using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Restaurant.Products.Foods
{
    internal class Cake : Dessert
    {
        public Cake(string name, decimal price, double calories) : base(name, price, calories)
        {
        }
    }
}
