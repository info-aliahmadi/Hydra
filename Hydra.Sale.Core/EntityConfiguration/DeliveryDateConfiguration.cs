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

            #region DeliveryDate Seed

            entity.HasData(
                new DeliveryDate()
                {
                    Id = 1,
                    Name = "1-2 days",
                    DisplayOrder = 1
                }, 
                new DeliveryDate()
                {
                    Id = 2,
                    Name = "3-5 days",
                    DisplayOrder = 2
                }, 
                new DeliveryDate()
                {
                    Id = 3,
                    Name = "1 week",
                    DisplayOrder = 3
                });

            #endregion
        }
    }
}
