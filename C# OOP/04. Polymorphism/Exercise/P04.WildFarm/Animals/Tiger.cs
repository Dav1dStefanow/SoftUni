using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.WildFarm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProducingSound()
        {
           return "ROAR!!!";
        }
        public override void GiveFood(Food food)
        {
            if (food is Meat)
            {
                this.weight += 1.0 * food.Quantity;
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
