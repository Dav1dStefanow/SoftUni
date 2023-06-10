using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.PizzaCalories
{
    internal class Dough
    {
        public Dough(string name, string type, int grams)
        {
            this.Name = name;
            this.Type = type;
            this.Grams = grams;
        }

        private string name;    
        private string type;    
        private int grams;

        private double nameModifier;
        private double typeModifier;

        public string Name
        {
            get { return name; }
            private set 
            { 
                string currName = value.ToLower();
                if(currName == "white")
                {
                    this.nameModifier = 1.5;
                }
                else if(currName == "wholegrain")
                {
                    this.nameModifier = 1.0;
                }
                else
                {
                   throw new ArgumentException($"Invalid type of dough.");
                }
                this.name = value; 
            }
        }
        public string Type
        {
            get { return this.type; }
            private set
            {
                string currType = value.ToLower();
                if (currType == "crispy")
                {
                    this.typeModifier = 0.9;
                }
                else if (currType == "chewy")
                {
                    this.typeModifier = 1.1;
                }
                else if (currType == "homemade")
                {
                    this.typeModifier = 1.0;
                }
                else
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }
                this.type = value; 
            }
        }
        public int Grams
        {
            get { return this.grams; }
            private set
            {
                if (value > 200 || value < 1) throw new ArgumentException("Dough weight should be in the range[1..200].");

                this.grams = value;
            }
        }
        public double GetTotalCalories()
        {
            return this.Grams * 2 * this.nameModifier * this.typeModifier;
        }
    }
}
