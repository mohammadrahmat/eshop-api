using eshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace eshop.domain
{
    public class EShopDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public EShopDbContext() { }

        public EShopDbContext(DbContextOptions<EShopDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                var configuration = GetConfiguration();

                dbContextOptionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

                base.OnConfiguring(dbContextOptionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EShopDbContext).Assembly);
        }

        private IConfiguration GetConfiguration() => new ConfigurationBuilder().AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json")).Build();
    }
}