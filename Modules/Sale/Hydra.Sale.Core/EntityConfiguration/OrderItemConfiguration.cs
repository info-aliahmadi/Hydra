using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity.ToTable("OrderItem", "Sale");

            entity.HasIndex(e => e.OrderId, "IX_OrderItem_OrderId");

            entity.Property(e => e.DiscountAmountTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PriceTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UnitPriceTax).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_OrderItem_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_OrderItem_ProductId_Product_Id");
        }
    }
}
