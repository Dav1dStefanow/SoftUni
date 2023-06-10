using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.ShoppingSpree
{
    internal class Product
    {
        public Product(string name,decimal cost) 
        {
            this.Name = name;
            this.Cost = cost;
        }
        private string name;
        private decimal cost;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public decimal Cost
        {
            get => this.cost;
            private set => this.cost = value;
        }
    }
}
