using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.FootballTeamGenerator
{
    internal class Team
    {
        public Team(string name) 
        { 
            this.Name = name;
            this.players = new List<Player>();
        }
        private string name;
        private List<Player> players;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public decimal Rating => GetRating();
        
        public IReadOnlyList<Player> Players => players;
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName) 
        {
            Player player = this.players.FirstOrDefault(x => x.Name == playerName);
            if (player == null)
            {
                Console.WriteLine($"Player {playerName} is not in Arsenal team.");
            }
            else players.Remove(player);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
        private decimal GetRating()
        {
            decimal rating = 0;
            foreach (Player player in this.players)
            {
                rating += (decimal)player.SkillLevel;
            }
            return Math.Ceiling(rating / players.Count);
        }
    }
}
