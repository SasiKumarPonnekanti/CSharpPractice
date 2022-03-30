namespace Cs_CoreWebApi.Models
{
    public class ApiDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(c=>c.category)
                .WithMany(p=>p.Products)
                .HasForeignKey(p=>p.CatogeryRowId);
            base.OnModelCreating(modelBuilder);
        }
    }


}
