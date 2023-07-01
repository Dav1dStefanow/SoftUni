using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        protected double price;
        protected int destructionLevel;
        protected Weapon(int destructionLevel)
        {
            this.DestructionLevel = destructionLevel;
        }
        public double Price
        {
            get { return this.price; }
            protected set { this.price = value; }
        }

        public int DestructionLevel
        {
            get { return this.destructionLevel; }
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                if (value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }
                this.destructionLevel = value;
            }
        }
    }
}
