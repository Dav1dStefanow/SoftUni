using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.FootballBetting.Data.Models
{
    public class Team
    {
        public Team() 
        { 
            this.AwayTeam = new HashSet<Game>();
            this.HomeTeam = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }
        [Key]
        public int TeamId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string LogoUrl { get; set; }
        [Column(TypeName = "char(3)")]
        public string Initials { get; set; }
        public decimal Budget { get; set; }
        [InverseProperty(nameof(Color.PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
        [InverseProperty(nameof(Color.SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }
        public ICollection<Game> HomeTeam { get; set; }
        public ICollection<Game> AwayTeam { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
