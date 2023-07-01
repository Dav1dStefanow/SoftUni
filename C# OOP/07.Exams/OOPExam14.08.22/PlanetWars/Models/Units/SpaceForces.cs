using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Units
{
    public class SpaceForces : MilitaryUnit
    {
        private const double prize = 11;
        public SpaceForces()
        {
            this.Cost = prize;
        }
    }
}
