using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double prize = 3.20;
        public BioChemicalWeapon(int destructionLevel) 
            : base(destructionLevel)
        {
            this.Price = prize;
        }
    }
}
