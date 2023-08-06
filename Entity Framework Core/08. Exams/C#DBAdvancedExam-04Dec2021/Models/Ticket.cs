using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_DBAdvancedExam_04Dec2021.Models
{
    public class Ticket
    {
        public Ticket() { }

        public int Id { get; set; }

        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }

        public Play Play { get; set; }

        [Required]
        public int TheatreId { get; set; }

        public Theatre Theatre { get; set; }
    }
}
