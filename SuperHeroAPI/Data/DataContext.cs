global using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = localhost,1433;Initial Catalog =superHero; User ID=sa; Password=Password123; TrustServerCertificate=True");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
