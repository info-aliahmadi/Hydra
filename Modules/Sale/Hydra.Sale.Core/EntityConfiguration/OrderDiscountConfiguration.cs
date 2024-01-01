using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class OrderDiscountConfiguration : IEntityTypeConfiguration<OrderDiscount>
    {
        public void Configure(EntityTypeBuilder<OrderDiscount> entity)
        {
            entity.ToTable("OrderDiscount", "Sale");

            entity.HasIndex(e => new { e.DiscountId, e.OrderId }, "IX_OrderDiscount");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);

            entity.HasOne(d => d.Discount).WithMany(p => p.OrderDiscounts)
            .HasForeignKey(d => d.DiscountId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_OrderDiscount_Discount");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDiscounts)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_OrderDiscount_Order");
        }
    }
}
