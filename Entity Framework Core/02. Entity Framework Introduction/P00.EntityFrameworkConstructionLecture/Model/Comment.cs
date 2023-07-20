using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P00.EntityFrameworkConstructionLecture.Model
{
    [Index(nameof(QuestionId), Name = "IX_Question123")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
