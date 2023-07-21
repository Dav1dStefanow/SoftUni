using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.StudentSystem.Data.Models
{
    [Index("PhoneNumber", IsUnique = true)]
    public class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourses>();
            Homeworks = new HashSet<Homework>();
        }
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(100)]
        public int Name { get; set; }
        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
