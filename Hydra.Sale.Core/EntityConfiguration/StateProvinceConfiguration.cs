using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class StateProvinceConfiguration : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> entity)
        {
            entity.ToTable("StateProvince", "Sale");

            entity.HasIndex(e => e.CountryId, "IX_StateProvince_CountryId");

            entity.Property(e => e.Abbreviation).HasMaxLength(100);
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.StateProvinces)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_StateProvince_Country");
        }
    }
}
