using PlanetWars.Models.Units;
using PlanetWars.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public interface IPlanet
    {
        string Name { get; }
        double Budget { get; }
        double MilitaryPower { get; }
        IReadOnlyCollection<IMilitaryUnit> Army { get; }
        IReadOnlyCollection<IWeapon> Weapons { get; }
        void AddUnit(IMilitaryUnit unit);
        void AddWeapon(IWeapon weapon);
        void TrainArmy();
        void Spend(double amount);
        void Profit(double amount);
        string PlanetInfo();
    }
}
