using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P01.StudentSystem.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Url { get; set; }
        public ResourceType ResourceType { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
