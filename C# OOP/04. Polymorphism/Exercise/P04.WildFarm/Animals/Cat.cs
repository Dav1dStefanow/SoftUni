using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.WildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight,string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProducingSound()
        {
            return "Meow";
        }
        public override void GiveFood(Food food)
        {
            if (food is Meat || food is Vegetable)
            {
                this.weight += 0.30 * food.Quantity;
                this.foodEaten += food.Quantity;
                Console.WriteLine(ProducingSound());
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}");
            }
        }
        
    }
}
