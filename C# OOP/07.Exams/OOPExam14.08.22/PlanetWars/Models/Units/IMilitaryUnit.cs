using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Units
{
    public interface IMilitaryUnit
    {
        double Cost { get; }
        int EnduranceLevel { get; }
        void IncreaseEndurance();
    }
}
