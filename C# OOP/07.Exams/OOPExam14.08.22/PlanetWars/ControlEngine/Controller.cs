using PlanetWars.Models.Planets;
using PlanetWars.Models.Units;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PlanetWars.ControlEngine
{
    public class Controller
    {
        private List<string> ArmyTypes = new List<string>()
        {
            nameof(StormTroopers),
            nameof(AnonymousImpactUnit),
            nameof(SpaceForces)
        };
        private List<string> WeaponTypes = new List<string>()
        {
            nameof(BioChemicalWeapon),
            nameof(NuclearWeapon),
            nameof(SpaceMissiles)
        };
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public IReadOnlyCollection<IPlanet> Planets => this.planets.Models;
        public string CreatePlanet(string planetName, double planetBudget)
        {
            if (this.Planets.Any(p => p.Name == planetName))
            {
                return $"Planet {planetName} is already added!";
            }
            IPlanet planet = new Planet(planetName, planetBudget);
            planets.AddItem(planet);
            return $"Successfully added Planet: {planetName}";
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!this.Planets.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!this.ArmyTypes.Any(t => t == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            IPlanet planet = this.Planets.First(p => p.Name == planetName);
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }
            else
            {
                foreach (var p in Planets)
                {
                    if (p.Name == planetName)
                    {
                        if (unitTypeName == nameof(StormTroopers))
                        {
                            IMilitaryUnit u = new StormTroopers();
                            p.Spend(u.Cost);
                            p.AddUnit(u);
                        }
                        else if (unitTypeName == nameof(AnonymousImpactUnit))
                        {
                            IMilitaryUnit u = new AnonymousImpactUnit();
                            p.Spend(u.Cost);
                            p.AddUnit(u);
                        }
                        else if (unitTypeName == nameof(SpaceForces))
                        {
                            IMilitaryUnit u = new SpaceForces();
                            p.Spend(u.Cost);
                            p.AddUnit(u);
                        }
                    }
                }
            }
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }
        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!this.Planets.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            IPlanet planet = this.Planets.First(p => p.Name == planetName);
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }
            if (!WeaponTypes.Contains(weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            foreach (var p in Planets)
            {
                if (p.Name == planetName)
                {
                    if (weaponTypeName == nameof(SpaceMissiles))
                    {
                        IWeapon w = new SpaceMissiles(destructionLevel);
                        p.Spend(w.Price);
                        p.AddWeapon(w);
                    }
                    else if (weaponTypeName == nameof(NuclearWeapon))
                    {
                        IWeapon w = new NuclearWeapon(destructionLevel);
                        p.Spend(w.Price);
                        p.AddWeapon(w);
                    }
                    else if (weaponTypeName == nameof(BioChemicalWeapon))
                    {
                        IWeapon w = new BioChemicalWeapon(destructionLevel);
                        p.Spend(w.Price);
                        p.AddWeapon(w);
                    }
                }
            }

            return $"{planetName} purchased {weaponTypeName}!";
        }
        public string SpecializeForces(string planetName)
        {
            IPlanet p = this.Planets.FirstOrDefault(p => p.Name == planetName);
            if (p == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (p.Army.Count == 0)
            {
                throw new InvalidOperationException($"No units available for upgrade!");
            }

            foreach (var planet in Planets)
            {
                if (planet.Name == planetName)
                {
                    foreach (var unit in planet.Army)
                    {
                        unit.IncreaseEndurance();
                    }
                    planet.Spend(1.25);
                }
            }

            return $"{planetName} has upgraded its forces!";
        }
        public string SpaceCombat(string firstPlanetName, string secondPlanetName)
        {
            IPlanet firstPlanet = planets.FindByName(firstPlanetName);
            IPlanet secondPlanet = planets.FindByName(secondPlanetName);

            string winningPlanet = null;
            string loosingPlanet = null;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (!firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                    && !secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                    && !secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    winningPlanet = firstPlanetName;
                    loosingPlanet = secondPlanetName;
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Weapons.Sum(w => w.Price));
                    firstPlanet.Profit(secondPlanet.Army.Sum(u => u.Cost));
                }
                else if (!firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                    && secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    winningPlanet = secondPlanetName;
                    loosingPlanet = firstPlanetName;
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Weapons.Sum(w => w.Price));
                    secondPlanet.Profit(firstPlanet.Army.Sum(u => u.Cost));
                }
            }
            else
            {
                if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
                {
                    winningPlanet = firstPlanetName;
                    loosingPlanet = secondPlanetName;
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Weapons.Sum(w => w.Price));
                    firstPlanet.Profit(secondPlanet.Army.Sum(u => u.Cost));
                }
                else if(firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
                {
                    winningPlanet = secondPlanetName;
                    loosingPlanet = firstPlanetName;
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Weapons.Sum(w => w.Price));
                    secondPlanet.Profit(firstPlanet.Army.Sum(u => u.Cost));
                }
            }
            planets.RemoveItem(loosingPlanet);
            return $"{winningPlanet} destructed {loosingPlanet}!";

        }
        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in Planets)
            {
                sb.AppendLine(planet.PlanetInfo());
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }
    }
}
