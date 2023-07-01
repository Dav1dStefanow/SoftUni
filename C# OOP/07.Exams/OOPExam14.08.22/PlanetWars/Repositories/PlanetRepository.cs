using PlanetWars.Models.Planets;
using PlanetWars.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.planets;

        public void AddItem(IPlanet planet)
        {
            this.planets.Add(planet);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = this.Models.FirstOrDefault(p => p.Name == name);
            return planet;
        }

        public bool RemoveItem(string name)
        {
            IPlanet planet = this.Models.FirstOrDefault(p => p.Name == name);
            if (planet != null)
            {
                this.planets.Remove(planet);
                return true;
            }
            return false;
        }
    }
}
