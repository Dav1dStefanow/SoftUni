using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGamesDatabase.Data.Models.Enumerators;

namespace BoardGamesDatabase.Data.Models
{
    public class BoardGame
    {
        public BoardGame()
        {
            this.BoardGameSellers = new HashSet<BoardGameSeller>(); 
        }
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }
        [Required]
        [Range(2018, 2023)]
        public int YearPublished { get; set; }
        [Required]
        public CategoryType CategoryType { get; set; }
        [Required]
        public string Mechanics { get; set; }
        [Required]
        public int? CreatorId { get; set; }
        public Creator Creator { get; set; }
        public virtual ICollection<BoardGameSeller> BoardGameSellers { get; set; }
    }
}
