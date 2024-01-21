using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("Order", "Sale");

            entity.HasIndex(e => e.CreatedOnUtc, "IX_Order_CreatedOnUtc").IsDescending();

            entity.HasIndex(e => e.ShipmentId, "IX_Order_ShippingAddressId");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.CustomerIp).HasMaxLength(50);
            entity.Property(e => e.ShippingTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ShippingAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ShippingAmountTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FinalPrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PaidDateUtc).HasPrecision(6);
            entity.Property(e => e.RefundedAmount).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId);

            entity.HasOne(d => d.Address).WithMany(p => p.Orders)
            .HasForeignKey(d => d.AddressId)
            .HasConstraintName("FK_Order_Address");

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.Orders)
            .HasForeignKey(d => d.ShippingMethodId)
            .HasConstraintName("FK_Order_ShippingMethod");

            entity.HasOne(d => d.UserCurrency).WithMany(p => p.Orders)
            .HasForeignKey(d => d.UserCurrencyId)
            .HasConstraintName("FK_Order_Currency");

            entity.HasOne(d => d.User).WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Order_User");
        }
    }
}
