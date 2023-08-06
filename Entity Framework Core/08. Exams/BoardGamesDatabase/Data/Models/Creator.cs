using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardGamesDatabase.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            this.Games = new HashSet<BoardGame>();
        }
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string LastName { get; set; }
        public virtual ICollection<BoardGame> Games { get; set; }
    }
}