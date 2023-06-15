using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.WildFarm.Animals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.livingRegion = livingRegion;
        }
        protected string livingRegion;
        public virtual string LivingRegion => this.livingRegion;

    }
}
