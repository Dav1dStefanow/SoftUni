using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    internal class Snake : Reptile
    {
        public Snake(string name)
            : base(name)
        {
            Name = name;
        }
    }
}
