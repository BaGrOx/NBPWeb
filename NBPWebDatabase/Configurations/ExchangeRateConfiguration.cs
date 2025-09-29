using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NBPWebDatabase.Models;

namespace NBPWebDatabase.Configurations
{
    /// <summary>
    /// Konfiguracja mapowania encji ExchangeRate.
    /// </summary>
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> r)
        {
            r.ToTable("ExchangeRates");

            r.HasKey(x => x.Id);

            r.Property(x => x.Currency)
             .HasMaxLength(128);

            r.Property(x => x.Code)
             .HasMaxLength(3);

            r.Property(x => x.Mid)
             .HasPrecision(18, 6);

            r.HasOne(x => x.ExchangeTable)
             .WithMany(t => t.Rates)
             .HasForeignKey(x => x.ExchangeTableId)
             .OnDelete(DeleteBehavior.Cascade);

            r.HasIndex(x => new { x.ExchangeTableId, x.Code })
             .IsUnique();

            r.HasIndex(x => x.Code);
        }
    }
}
