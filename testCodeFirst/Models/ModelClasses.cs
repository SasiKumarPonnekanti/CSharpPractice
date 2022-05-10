using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCodeFirst.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }
        [Required]
        public int CourseDuration { get; set; }
        [Required]
        public int Fees { get; set; }

        [Required, StringLength(100)]
        public string DegreeType { get; set; }

        public ICollection<Student> Students { get; set; }

    }
    public class Student
    {
        [Key]
        public int StudentUniqueId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }
        [Required]
        public int CouresYear { get; set; }
        [Required]
        [StringLength(100)]
        public string FeeStatus { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
