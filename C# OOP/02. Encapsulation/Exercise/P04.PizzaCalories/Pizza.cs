using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.PizzaCalories
{
    internal class Pizza
    {
        public Pizza(string name, Dough dough) 
        { 
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        private string name;
        private Dough dough;
        private List<Topping> toppings;
        public string Name 
        {
            get { return this.name; } 
            private set 
            {
                if (value.Length < 1 || value.Length > 15) throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                
                this.name = value; 
            }
        }
        public Dough Dough { get { return this.dough; } private set { this.dough = value; } }
        public IReadOnlyList<Topping> Toppings => this.toppings;
        
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count > 9) throw new Exception("Number of toppings should be in range [0..10].");
            else this.toppings.Add(topping);
        }
        public void TotalCalories()
        {
            double totalCals = this.Dough.GetTotalCalories();
            foreach (var topping in this.toppings)
            {
                totalCals += topping.GetTotalCalories();
            }
            Console.WriteLine($"{this.Name} - {totalCals:F2} Calories.");
        }
    }
}
