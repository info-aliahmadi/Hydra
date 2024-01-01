using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class RelatedProductConfiguration : IEntityTypeConfiguration<RelatedProduct>
    {
        public void Configure(EntityTypeBuilder<RelatedProduct> entity)
        {
            entity.ToTable("RelatedProduct", "Sale");

            entity.HasIndex(e => e.ProductId1, "IX_RelatedProduct_ProductId1");

            entity.HasOne(d => d.ProductId1Navigation).WithMany(p => p.RelatedProductProductId1Navigations)
            .HasForeignKey(d => d.ProductId1)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_RelatedProduct_Product");

            entity.HasOne(d => d.ProductId2Navigation).WithMany(p => p.RelatedProductProductId2Navigations)
            .HasForeignKey(d => d.ProductId2)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_RelatedProduct_Product1");
        }
    }
}
