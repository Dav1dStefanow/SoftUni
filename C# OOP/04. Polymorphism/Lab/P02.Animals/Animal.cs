using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Animals
{
    public abstract class Animal
    {
        public Animal(string name, string food)
        {
            this.name = name;
            this.food = food;
        }
        protected string name;
        protected string food;
        public string Name  => this.name;
        
        public string Food => this.food;
        
        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my favorite food is {this.Food}";
        }
    }
}
