using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductProductAttributeConfiguration : IEntityTypeConfiguration<ProductProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductProductAttribute> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Product_Attribute_Mapping");

            entity.ToTable("ProductProductAttribute", "Sale");

            entity.HasIndex(e => new { e.AttributeId, e.ProductId }, "IX_PCM_Product_and_Attribute");

            entity.HasIndex(e => e.AttributeId, "IX_Product_Attribute_Mapping_AttributeId");

            entity.HasIndex(e => e.ProductId, "IX_Product_Attribute_Mapping_ProductId");

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributes)
            .HasForeignKey(d => d.AttributeId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductAttribute_Attribute");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributes)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductAttribute_Product");
        }
    }
}
