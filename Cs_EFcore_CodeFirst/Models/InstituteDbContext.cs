using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cs_EFcore_CodeFirst.Models
{
    internal class InstituteDbContext :DbContext
    {
        public InstituteDbContext()
        {

        }
        public Student Student { get; set; }
        public Course Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Business;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>().HasOne(c=>c.Course).WithMany(s=>s.Students).HasForeignKey(s => s.CourseId);
        //}
    }
}
