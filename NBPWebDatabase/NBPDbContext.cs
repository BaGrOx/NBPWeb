using Microsoft.EntityFrameworkCore;
using NBPWebDatabase.Configurations;
using NBPWebDatabase.Models;

namespace NBPWebDatabase
{
    public class NbpDbContext : DbContext
    {
        public NbpDbContext(DbContextOptions<NbpDbContext> options) : base(options)
        {
        }

        public DbSet<ExchangeTable> Tables => Set<ExchangeTable>();
        public DbSet<ExchangeRate> Rates => Set<ExchangeRate>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfiguration(new ExchangeRateConfiguration());
            b.ApplyConfiguration(new ExchangeTableConfiguration());
        }
    }
}
