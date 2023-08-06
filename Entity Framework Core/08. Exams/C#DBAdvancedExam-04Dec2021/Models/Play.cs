using C_DBAdvancedExam_04Dec2021.Models.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace C_DBAdvancedExam_04Dec2021.Models
{
    public class Play
    {
        public Play()
        {
            this.Actors = new HashSet<Cast>();
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public TimeSpan Duration { get; set; } 

        [Required]
        public double Rating { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MaxLength (30)]
        [MinLength(4)]
        public string ScreenWriter { get; set; }

        public virtual ICollection<Cast> Actors { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}