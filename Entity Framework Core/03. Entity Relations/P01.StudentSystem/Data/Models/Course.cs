using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            Resources = new HashSet<Resource>();
            Homeworks = new HashSet<Homework>();
            StudentCourses = new HashSet<StudentCourses>();
        }
        [Key]
        public int CourseId { get; set; }
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
