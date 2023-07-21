using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P01.StudentSystem.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ContentType = P01.StudentSystem.Data.Models.Enumerations.ContentType;

namespace P01.StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
