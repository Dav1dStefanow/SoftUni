using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight) 
        { 
            this.name = name;
            this.weight = weight;
        }

        protected string name;
        protected double weight;
        protected int foodEaten;
        public virtual string Name => this.name;
        public virtual double Weight => this.weight;
        public virtual int FoodEaten => this.foodEaten;
        public abstract string ProducingSound();
        public abstract void GiveFood(Food food);
    }
}
