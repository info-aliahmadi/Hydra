using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class DeliveryDateConfiguration : IEntityTypeConfiguration<DeliveryDate>
    {
        public void Configure(EntityTypeBuilder<DeliveryDate> entity)
        {
            entity.ToTable("DeliveryDate", "Sale");

            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}
