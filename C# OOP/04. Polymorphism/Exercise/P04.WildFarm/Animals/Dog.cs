using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProducingSound()
        {
            return "Woof!";
        }
        public override void GiveFood(Food food)
        {
            if (food is Meat)
            {
                this.weight += 0.25 * food.Quantity;
                this.foodEaten += food.Quantity;
                Console.WriteLine(ProducingSound());
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}");
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
