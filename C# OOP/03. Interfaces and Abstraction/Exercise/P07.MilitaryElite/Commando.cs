using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, IPrivate, ISoldier
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(corps) 
        { 
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            this.missions = new List<Mission>();
        }
        public decimal Salary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        private List<Mission> missions;   
        public IReadOnlyList<Mission> Missions => missions;
        public void AddMission(Mission mission)
        {
            this.missions.Add(mission);
        }
        public void CompleteMision(string missionName)
        {
            foreach(var m in missions)
            {
                if(m.CodeName == missionName)
                {
                    m.State = "Finished";
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            foreach(var m in missions)
            {
                sb.AppendLine($"Code Name: {m.CodeName} State: {m.State}"); 
            }
            return sb.ToString();
        }
    }
}
