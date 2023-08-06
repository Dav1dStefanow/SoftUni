using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFExam06._04._2022.Models
{
    public class Coach
    {
        public Coach() 
        {
            this.Team =  new HashSet<Footballer>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        public virtual ICollection<Footballer> Team { get; set; }
    }
}