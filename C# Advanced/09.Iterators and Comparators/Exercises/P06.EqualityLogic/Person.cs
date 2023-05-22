using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.EqualityLogic
{
    internal class Person : IComparable<Person>
    {
        public Person(string name, int age) 
        { Name = name; Age = age; }

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

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if(result == 0)
            {
                result = Age.CompareTo(other.Age);
            }
            return result;
        }
        public override int GetHashCode() => Name.GetHashCode() ^ Age.GetHashCode();
        public override bool Equals(object obj)
        {
            var other = obj as Person;
            if(other == null) return false;

            return Age == other.Age && Name == other.Name; 
        }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
