using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class OrderNoteConfiguration : IEntityTypeConfiguration<OrderNote>
    {
        public void Configure(EntityTypeBuilder<OrderNote> entity)
        {
            entity.ToTable("OrderNote", "Sale");

            entity.HasIndex(e => e.OrderId, "IX_OrderNote_OrderId");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.Note)
            .IsRequired()
            .HasMaxLength(300);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderNotes)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_OrderNote_Order");

            entity.HasOne(d => d.User).WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_OrderNote_User");
        }
    }
}
