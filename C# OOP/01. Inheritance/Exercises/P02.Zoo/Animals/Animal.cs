using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    abstract class Animal
    {
        protected Animal(string name) 
        { 
            this.Name = name;
        }
        protected string name;
        public string Name 
        { 
            get { return name; }
            set { name = value; }
        }
        public override string ToString()
        {
            return $"This animal is called {Name}"; 
        }
    }
}
