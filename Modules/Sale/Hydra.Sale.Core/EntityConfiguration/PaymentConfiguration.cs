using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_RecurringPayment");

            entity.ToTable("Payment", "Sale");

            entity.HasIndex(e => e.OrderId, "IX_RecurringPayment_InitialOrderId");

            entity.Property(e => e.CardCvv2).HasMaxLength(20);
            entity.Property(e => e.CardExpirationMonth).HasMaxLength(10);
            entity.Property(e => e.CardExpirationYear).HasMaxLength(10);
            entity.Property(e => e.CardName).HasMaxLength(50);
            entity.Property(e => e.CardNumber).HasMaxLength(50);
            entity.Property(e => e.CardType).HasMaxLength(50);
            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.MaskedCreditCardNumber).HasMaxLength(100);
            entity.Property(e => e.PaymentDateUtc).HasPrecision(6);
            entity.Property(e => e.PaymentTrackingCode).HasMaxLength(200);
            entity.Property(e => e.TransactionTrackingCode).HasMaxLength(200);

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Payment_Order");
        }
    }
}
