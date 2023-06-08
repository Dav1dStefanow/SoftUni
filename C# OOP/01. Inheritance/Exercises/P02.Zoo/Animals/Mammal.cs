using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    internal class Mammal : Animal
    {
        public Mammal(string name)
            : base(name)
        {
            Name = name;
        }
    }
}
