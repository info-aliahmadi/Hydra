using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> entity)
        {
            entity.ToTable("Currency", "Sale");

            entity.HasIndex(e => e.DisplayOrder, "IX_Currency_DisplayOrder");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.CurrencyCode)
            .IsRequired()
            .HasMaxLength(5);
            entity.Property(e => e.CustomFormatting).HasMaxLength(50);
            entity.Property(e => e.DisplayLocale).HasMaxLength(50);
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedOnUtc).HasPrecision(6);
        }
    }
}
