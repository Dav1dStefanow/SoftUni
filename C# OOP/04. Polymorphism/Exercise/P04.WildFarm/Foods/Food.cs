﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.WildFarm.Foods
{
    public abstract class Food
    {
        protected Food(int quantity) { this.quantity = quantity; }
        protected int quantity;
        public virtual int Quantity => this.quantity;
    }
}
