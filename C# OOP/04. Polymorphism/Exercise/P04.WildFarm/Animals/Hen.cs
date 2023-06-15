using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void GiveFood(Food food)
        {
            this.weight += 0.35 * food.Quantity;
            this.foodEaten += food.Quantity;
            Console.WriteLine(ProducingSound());
        }

        public override string ProducingSound()
        {
            return "Cluck";
        }
    }
}
