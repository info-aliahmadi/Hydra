using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ShipmentItemConfiguration : IEntityTypeConfiguration<ShipmentItem>
    {
        public void Configure(EntityTypeBuilder<ShipmentItem> entity)
        {
            entity.ToTable("ShipmentItem", "Sale");

            entity.HasIndex(e => e.ShipmentId, "IX_ShipmentItem_ShipmentId");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.ShipmentItems)
            .HasForeignKey(d => d.OrderItemId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ShipmentItem_OrderItem");

            entity.HasOne(d => d.Shipment).WithMany(p => p.ShipmentItems)
            .HasForeignKey(d => d.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ShipmentItem_Shipment");
        }
    }
}
