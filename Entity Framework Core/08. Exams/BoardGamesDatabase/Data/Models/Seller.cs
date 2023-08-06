using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDatabase.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            this.BoardGameSellers = new HashSet<BoardGameSeller>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"(www\.[a-zA-Z0-9\-]{2,256}\.com)")]
        public string WebSite { get; set; }

        public virtual ICollection<BoardGameSeller> BoardGameSellers { get; set; }
    }
}
