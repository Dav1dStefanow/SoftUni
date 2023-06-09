using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03.ValidationOfData
{
    internal class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
            this.Name = firstName + " " + lastName;
        }
        private string name;
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;


        public string FirstName
        {
            get { return this.firstName; }
            private set 
            { 
               // if(value.Length < 3) throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                if (!Regex.Match(value, "[A-Z][a-z]{2,}").Success) throw new ArgumentException("First name cannot contain fewer than 3 symbols!");

                    this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length < 3) throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");

                    this.lastName = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            private set 
            { 

                if(value <= 0) throw new ArgumentException("Age cannot be zero or a negative integer!");

                    this.age = value;
            }
        }
        public decimal Salary
        {
            get { return this.salary; }
            private set 
            {
                if (value < 650) throw new ArgumentException("Salary cannot be less than 650 leva!");

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }
        public override string ToString()
        {
            return $"{Name} recieves {Salary:F2} leva.";
        }
    }
}
