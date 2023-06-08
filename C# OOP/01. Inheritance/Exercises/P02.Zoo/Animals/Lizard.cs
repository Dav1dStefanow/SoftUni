using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    internal class Lizard : Reptile
    {
        public Lizard(string name)
            : base(name)
        {
            Name = name;
        }
    }
}
