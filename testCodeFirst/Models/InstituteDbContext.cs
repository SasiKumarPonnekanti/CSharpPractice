using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace testCodeFirst.Models
{
    internal class InstituteDbContext : DbContext
    {
        public InstituteDbContext()
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Business1;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
