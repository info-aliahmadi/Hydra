using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductWarehouseInventory");

            entity.ToTable("ProductInventory", "Sale");

            entity.HasIndex(e => e.ProductId, "IX_ProductWarehouseInventory_ProductId");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductInventories)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductInventory_Product");
        }
    }
}
