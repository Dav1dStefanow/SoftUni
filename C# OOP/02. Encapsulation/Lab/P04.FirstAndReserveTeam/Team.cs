using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.FirstAndReserveTeam
{
    internal class Team
    {
        public Team(string name) 
        { 
            Name = name;
        }
        private string name;
        private List<Person> firstTeam = new List<Person>();
        private List<Person> reserveTeam = new List<Person>();

        public string Name 
        {
            get { return name; } 
            private set { name = value; }
        }
        public IReadOnlyList<Person> FirstTeam => this.firstTeam;
        public IReadOnlyList<Person> ReserveTeam => this.reserveTeam;

        public void AddPlayer(Person person)
        {
            if(person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First team has {FirstTeam.Count} players.");
            sb.AppendLine($"Reserve team has {ReserveTeam.Count} players.");
            return sb.ToString();
        }
    }
}
