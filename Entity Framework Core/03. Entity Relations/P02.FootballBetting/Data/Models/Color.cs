using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.FootballBetting.Data.Models
{
    public class Color
    {
        public Color() 
        {
            this.PrimaryKitColor = new HashSet<Team>();
            this.SecondaryKitColor = new HashSet<Team>();
        }

        [Key]
        public int ColorId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Team> PrimaryKitColor { get; set; }
        public ICollection<Team> SecondaryKitColor { get; set; }
    }
}
