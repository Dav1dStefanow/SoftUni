using PlanetWars.Models.Units;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository unitRepository;
        private WeaponRepository weaponRepository;
        private string name;
        private double budget;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.unitRepository = new UnitRepository();
            this.weaponRepository = new WeaponRepository();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentNullException("Planet name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public double Budget
        {
            get { return this.budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Budget's amount cannot be negative.");
                }
                this.budget = value;
            }
        }
        public double MilitaryPower => Math.Round(this.CalculateMilitaryPower(), 3);
        
        public IReadOnlyCollection<IMilitaryUnit> Army => this.unitRepository.Models;
        public IReadOnlyCollection<IWeapon> Weapons => this.weaponRepository.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            unitRepository.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {

            weaponRepository.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {string.Join(" ", Army.Select(u => u.GetType().Name))}");
            sb.AppendLine($"--Combat equipment: {string.Join(" ", Weapons.Select(w => w.GetType().Name))}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");
            return sb.ToString().Trim();
        }

        public void Profit(double amount) => this.Budget += amount;

        public void Spend(double amount)
        {
            if (this.Budget - amount < 0)
            {
                throw new InvalidOperationException("Budget too low!");
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in this.unitRepository.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public double CalculateMilitaryPower()
        {
            double totalAmmount = unitRepository.Models.Sum(u => u.EnduranceLevel) + weaponRepository.Models.Sum(w => w.DestructionLevel);
            if (unitRepository.Models.Any(u => u.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmmount *= 1.3;
            }
            if (weaponRepository.Models.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmmount *= 1.45;
            }
            return totalAmmount;
        }
    }
}
