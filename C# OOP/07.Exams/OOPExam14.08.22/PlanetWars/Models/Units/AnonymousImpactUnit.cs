using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Units
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double prize = 30;
        public AnonymousImpactUnit()
        {
            this.Cost = prize;
        }
    }
}
