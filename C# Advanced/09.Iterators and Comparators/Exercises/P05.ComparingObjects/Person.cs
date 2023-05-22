using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.ComparingObjects
{
    internal class Person : IComparable<Person>
    {
        public Person(string name, int age,string town) 
        { Name = name;Age = age;Town = town; }

        private string name;
        private int age;
        private string town;

        public string Name
        { 
            get { return name; }
            set { name = value; }
        }
        public int Age 
        { 
            get { return age;}
            set { age = value; }
        }
        public string Town
        {
            get { return town;}
            set { town = value; }
        }
        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if(result == 0)
            {
                result = Age.CompareTo(other.Age);
            }
            if(result == 0)
            {
                result = Town.CompareTo(other.Town);
            }
            return result;
        }
        
    }
}
