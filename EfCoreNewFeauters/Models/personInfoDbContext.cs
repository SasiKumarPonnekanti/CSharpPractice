using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_2._0___New_Features.Models
{
    internal class personInfoDbContext: DbContext
    {

        public DbSet<Person> Persons { get; set;}
        public personInfoDbContext()
        {
        }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=.;Database=PersonInfoDB;Trusted_Connection=True;");
                base.OnConfiguring(optionsBuilder);

        }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            


            //The Person table will have the current address as its own property
            modelBuilder.Entity<Person>()
                 .OwnsOne(p => p.CurrentAddress)
                 .OwnsOne(r => r.Region);

            //The Table Splitting, this will generate two tables Persons and Region
            modelBuilder.Entity<Person>()
                .OwnsOne(p => p.PermanentAddress)
                .ToTable("Region").
                OwnsOne(r => r.Region);
        }
       
    }
}
