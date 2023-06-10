using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.ShoppingSpree
{
    internal class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public string Name
        {
            get => name; 
            set 
            { 
                if (value == null) throw new ArgumentException("Name cannot be an empty string");

                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            set
            {
                if(value < 0) throw new ArgumentException("Money cannot be a negative number");

                this.money = value;
            }
        }
        public IReadOnlyList<Product> BagOfProducts => this.bagOfProducts;
        
        public void BuyProduct(Product product)
        {
            if(Money - product.Cost >= 0)
            {
                bagOfProducts.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
        
    }
}
