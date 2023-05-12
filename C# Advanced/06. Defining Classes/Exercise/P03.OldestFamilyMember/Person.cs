﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.OldestFamilyMember
{
    internal class Person
    {
        public Person (string name, int age)
        {
            Name = name;
            Age = age;
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

        public string Introduce()
        {
            return $"{Name} {Age}";
        }
    }
}
