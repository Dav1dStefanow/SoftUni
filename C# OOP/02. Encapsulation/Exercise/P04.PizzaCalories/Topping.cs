using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.PizzaCalories
{
    internal class Topping
    {
        public Topping(string type, int grams) 
        { 
            this.Type = type;
            this.Grams = grams;
        }

        private string type;   
        private int grams;
        private double typeModifier;
        public string Type
        {
            get { return this.type; }
            set 
            { 
                if(value == "Meat")
                {
                    this.typeModifier = 1.2;
                }
                else if (value == "Veggies")
                {
                    this.typeModifier = 0.8;
                }
                else if (value == "Cheese")
                {
                    this.typeModifier = 1.1;
                }
                else if (value == "Sauce")
                {
                    this.typeModifier = 0.9;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value; 
            }
        }
        public int Grams
        {
            get { return this.grams; }
            set 
            {
                if( value > 50 || value < 1 ) throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                this.grams = value; 
            }
        }
        public double GetTotalCalories()
        {
            return this.Grams * 2 * this.typeModifier; 
        }
    }
}
