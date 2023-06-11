using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.DefineAnInterfaceIPerson
{
    public class Citizen : IPerson
    {
        public Citizen(string name, int age) 
        { this.Name = name; this.Age = age; }
        public string Name { get ; set ; }
        public int Age { get ; set ; }
    }
}
