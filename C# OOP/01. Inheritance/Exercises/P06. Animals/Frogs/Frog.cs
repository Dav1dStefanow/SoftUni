using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Animals.Frogs
{
    internal class Frog : Animal
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSoung()
        {
            return "Rabbit";
        }
    }
}
