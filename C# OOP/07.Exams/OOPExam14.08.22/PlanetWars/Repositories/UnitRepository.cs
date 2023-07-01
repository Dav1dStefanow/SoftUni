using PlanetWars.Models.Units;
using PlanetWars.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;
        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => this.units;
        public void AddItem(IMilitaryUnit unit)
        {
            units.Add(unit);
        }

        public IMilitaryUnit FindByName(string typeName)
        {
            IMilitaryUnit unit = this.Models.FirstOrDefault(w => w.GetType().Name == typeName);
            return unit;
        }

        public bool RemoveItem(string typeName)
        {
            IMilitaryUnit unit = this.Models.FirstOrDefault(u => u.GetType().Name == typeName);
            if (unit != null)
            {
                this.units.Remove(unit);
                return true;
            }
            return false;
        }
    }
}
