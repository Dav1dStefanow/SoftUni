using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Animals.Cats
{
    internal class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSoung()
        {
            return "MEOW";
        }
    }
}
