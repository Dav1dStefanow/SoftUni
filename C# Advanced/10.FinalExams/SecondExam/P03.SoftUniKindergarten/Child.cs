using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.SoftUniKindergarten
{
    internal class Child : IComparable<Child>
    {
        public Child(string firstName,string lastName,int age,string parentName,string contactNum) 
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ParentName = parentName;
            ContactNum = contactNum;
        }

        private string firstName;
        private string lastName;
        private int age;
        private string parentName;
        private string contactNum;

        public string FirstName
        { 
            get { return this.firstName; } 
            set { this.firstName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public string ParentName
        {
            get { return this.parentName; }
            set { this.parentName = value; }
        }
        public string ContactNum
        {
            get { return this.contactNum; }
            set { this.contactNum = value; }
        }
        public override string ToString()
        {
            return $"Child: {FirstName} {LastName}, Age: {Age}, Contact info: {ParentName} - {ContactNum}";
        }

        public int CompareTo(Child other)
        {
            int result = Age.CompareTo(other.Age);
            if(result == 0)
            {
                result = FirstName.CompareTo(other.FirstName);
            }
            return result;
        }
    }
}
