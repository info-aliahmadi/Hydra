using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class TaxCategoryConfiguration : IEntityTypeConfiguration<TaxCategory>
    {
        public void Configure(EntityTypeBuilder<TaxCategory> entity)
        {
            entity.ToTable("TaxCategory", "Sale");

            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}
