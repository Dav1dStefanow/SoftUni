using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace P07.MilitaryElite
{
    public class LieutenantGeneral : ILieutenantGeneral, ISoldier
    {
        public LieutenantGeneral(int Id, string firstName, string lastName, decimal salary) 
        { 
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.privates = new List<Private>();
        }
        private List<Private> privates; 
        public IReadOnlyList<Private> Privates => privates;
        public decimal Salary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public void AddPrivate(Private @private)
        {
            this.privates.Add(@private);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}");
            sb.AppendLine("Privates:");
            foreach (var p in this.privates)
            {
                sb.AppendLine($"Name: {p.FirstName} {p.LastName} Id: {p.Id} Salary: {p.Salary}");
            }
            return sb.ToString().Trim();
        }
    }
}
