﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.FoodShortage
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group) 
        { 
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name { get; set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; set; }
        public int BuyFood()
        {
            return this.Food += 5;
        }
    }
}
