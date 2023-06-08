using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Person.People
{
    abstract class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private string name;
        private int age;

        public string Name 
        { 
            get { return name; } 
            set { name = value; }
        }
        public int Age 
        { 
            get { return age; } 
            set { age = value; } 
        }
        public override string ToString()
        {

            return $"Name: {Name}, Age: {Age}";
        }
    }
}
