using PlanetWars.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void AddItem(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public IWeapon FindByName(string typeName)
        {
            IWeapon weapon = this.Models.FirstOrDefault(w => w.GetType().Name == typeName);
            return weapon;
        }

        public bool RemoveItem(string typeName)
        {
            IWeapon weapon = this.Models.FirstOrDefault(w => w.GetType().Name == typeName);
            if (weapon != null)
            {
                this.weapons.Remove(weapon);
                return true;
            }
            return false;
        }
    }
}
