using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Units
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        protected double cost;
        protected int enduranceLevel = 1;

        public double Cost
        {
            get { return this.cost; }
            protected set { this.cost = value; }
        }

        public int EnduranceLevel
        {
            get { return this.enduranceLevel; }
            protected set { this.enduranceLevel = value; }
        }

        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel + 1 > 20)
            {
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
            this.EnduranceLevel++;
        }
    }
}
