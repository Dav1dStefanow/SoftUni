using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P05.Restaurant.Products
{
    abstract class Product
    {

        private string name;
        private decimal price;

        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
        public decimal Price 
        { 
            get { return price;} 
            set { price = value; }
        }
        public virtual string ToString()
        {
            return $"Type: {this.GetType().Name}, Name: {this.Name} , Price: {this.Price}";
        }
    }
}
