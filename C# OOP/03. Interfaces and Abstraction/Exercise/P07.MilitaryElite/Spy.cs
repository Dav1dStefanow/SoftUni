using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P07.MilitaryElite
{
    public class Spy : ISoldier
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) 
        { 
            this.CodeNumber = codeNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public int CodeNumber { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString();
        }
    }
    
}
