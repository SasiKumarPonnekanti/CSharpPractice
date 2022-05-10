﻿namespace Cs_ProCatApi.Models
{
    public class ApiDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ErrorLog> ErrorLogs { get; set; }

        public DbSet<LogInfo> LogInfos { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(c => c.category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryRowId);
            base.OnModelCreating(modelBuilder);
        }
    }

}