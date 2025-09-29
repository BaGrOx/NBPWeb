using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NBPWebDatabase.Models;

namespace NBPWebDatabase.Configurations
{
    /// <summary>
    /// Konfiguracja mapowania encji ExchangeTable.
    /// </summary>
    public class ExchangeTableConfiguration : IEntityTypeConfiguration<ExchangeTable>
    {
        public void Configure(EntityTypeBuilder<ExchangeTable> t)
        {
            t.ToTable("ExchangeTables");

            t.HasKey(x => x.Id);

            t.Property(x => x.Table)
             .HasMaxLength(1);

            t.Property(x => x.No)
             .HasMaxLength(32);

            t.HasIndex(x => x.No).IsUnique();
            t.HasIndex(x => x.EffectiveDate);

            t.HasMany(x => x.Rates)
             .WithOne(r => r.ExchangeTable!)
             .HasForeignKey(r => r.ExchangeTableId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
