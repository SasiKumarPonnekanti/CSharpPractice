using Microsoft.EntityFrameworkCore;

namespace Project_Bahubali.Models
{
    public class ScoresDbContext: DbContext
    {
        public DbSet<Score> Scores { get; set; }
        public ScoresDbContext(DbContextOptions<ScoresDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
