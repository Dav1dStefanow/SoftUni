using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Units
{
    public class StormTroopers : MilitaryUnit
    {
        private const double prize = 2.5;
        public StormTroopers() 
        {
            this.Cost = prize;
        }
    }
}
