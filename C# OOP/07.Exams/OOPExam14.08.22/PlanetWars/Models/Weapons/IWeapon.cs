using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public interface IWeapon
    {
        double Price { get; }
        int DestructionLevel { get; }
    }
}
