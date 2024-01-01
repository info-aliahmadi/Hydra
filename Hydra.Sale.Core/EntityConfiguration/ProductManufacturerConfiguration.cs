using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductManufacturerConfiguration : IEntityTypeConfiguration<ProductManufacturer>
    {
        public void Configure(EntityTypeBuilder<ProductManufacturer> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Product_Manufacturer_Mapping");

            entity.ToTable("ProductManufacturer", "Sale");

            entity.HasIndex(e => new { e.ManufacturerId, e.ProductId }, "IX_PMM_Product_and_Manufacturer");

            entity.HasIndex(e => e.ManufacturerId, "IX_Product_Manufacturer_Mapping_ManufacturerId");

            entity.HasIndex(e => e.ProductId, "IX_Product_Manufacturer_Mapping_ProductId");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.ProductManufacturers)
            .HasForeignKey(d => d.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductManufacturer_Manufacturer");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductManufacturers)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductManufacturer_Product");
        }
    }
}
