using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> entity)
        {
            entity.ToTable("ProductTag", "Sale");

            entity.HasIndex(e => e.Name, "IX_ProductTag_Name");

            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(70);
        }
    }
}
