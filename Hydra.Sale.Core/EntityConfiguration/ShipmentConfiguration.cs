using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> entity)
        {
            entity.ToTable("Shipment", "Sale");

            entity.HasIndex(e => e.OrderId, "IX_Shipment_OrderId");

            entity.Property(e => e.AdminComment).HasMaxLength(300);
            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.DeliveryDateUtc).HasPrecision(6);
            entity.Property(e => e.ReadyForPickupDateUtc).HasPrecision(6);
            entity.Property(e => e.ShippedDateUtc).HasPrecision(6);
            entity.Property(e => e.TotalWeight).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TrackingNumber).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.Shipments)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Shipment_Order");
        }
    }
}
