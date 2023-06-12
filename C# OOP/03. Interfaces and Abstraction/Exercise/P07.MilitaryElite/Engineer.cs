using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, ISoldier, IPrivate
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(corps) 
        { 
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            repairs = new List<Repair>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public decimal Salary { get; set; }

        public List<Repair> repairs { get; set; }
        public IReadOnlyList<Repair> Repair => repairs;
        public void AddRepair(Repair repair )
        {
            this.repairs.Add( repair ); 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var r in repairs)
            {
                sb.AppendLine($"    Part Name: {r.Name} Hours Worked: {r.Hours}");
            }
            return sb.ToString();
        }
    }
}
