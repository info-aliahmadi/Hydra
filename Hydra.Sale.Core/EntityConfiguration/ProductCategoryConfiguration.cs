using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Product_Category_Mapping");

            entity.ToTable("ProductCategory", "Sale");

            entity.HasIndex(e => new { e.CategoryId, e.ProductId }, "IX_PCM_Product_and_Category");

            entity.HasIndex(e => e.CategoryId, "IX_Product_Category_Mapping_CategoryId");

            entity.HasIndex(e => e.ProductId, "IX_Product_Category_Mapping_ProductId");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCategories)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductCategory_Category");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategories)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductCategory_Product");
        }
    }
}
