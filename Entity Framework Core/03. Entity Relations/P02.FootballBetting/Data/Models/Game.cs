using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P02.FootballBetting.Data.Models
{
    public class Game
    {
        public Game() 
        { 
            this.Bets = new HashSet<Bet>();
            this.Statistics = new HashSet<PlayerStatistic>();
        }
        [Key]
        public int GameId { get; set; }
        [InverseProperty(nameof(Team.HomeTeam))]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        [InverseProperty(nameof(Team.AwayTeam))]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeTeamGoals { get;set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        public double HomeTeamBetRate { get; set; }
        public double AwayTeamBetRate { get; set; }
        public double DrawBetRate { get; set; }
        public string Result { get; set; }
        public ICollection<Bet> Bets { get; set; }
        public ICollection<PlayerStatistic> Statistics { get; set; }
    }
}
