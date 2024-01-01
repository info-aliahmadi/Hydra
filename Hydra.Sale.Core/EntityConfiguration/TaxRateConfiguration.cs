using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class TaxRateConfiguration : IEntityTypeConfiguration<TaxRate>
    {
        public void Configure(EntityTypeBuilder<TaxRate> entity)
        {
            entity.ToTable("TaxRate", "Sale");

            entity.Property(e => e.Percentage).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Country).WithMany(p => p.TaxRates)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_TaxRate_Country");

            entity.HasOne(d => d.StateProvince).WithMany(p => p.TaxRates)
            .HasForeignKey(d => d.StateProvinceId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_TaxRate_StateProvince");

            entity.HasOne(d => d.TaxCategory).WithMany(p => p.TaxRates)
            .HasForeignKey(d => d.TaxCategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_TaxRate_TaxCategory");
        }
    }
}
