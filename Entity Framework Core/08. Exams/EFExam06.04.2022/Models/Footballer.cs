using EFExam06._04._2022.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExam06._04._2022.Models
{
    public class Footballer
    {
        public Footballer() 
        {
            this.Footballers = new HashSet<TeamFootballer>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public Skill BestSkillType { get; set; }

        [Required]
        public Position PositionType { get; set; }

        [Required]
        public int CoachId { get; set;}

        public Coach Coach { get; set; }

        public virtual ICollection<TeamFootballer> Footballers { get; set; }

    }
}
