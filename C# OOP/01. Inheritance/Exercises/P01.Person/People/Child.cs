using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P01.Person.People
{
    internal class Child : Person
    {
        public Child(string name, int age) 
            :base(name, age)
        {
            Name = name;
            Age = age;
        }
    }
}
