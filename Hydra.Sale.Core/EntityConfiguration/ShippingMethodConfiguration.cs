using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
    {
        public void Configure(EntityTypeBuilder<ShippingMethod> entity)
        {
            entity.ToTable("ShippingMethod", "Sale");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(70);

            #region ShippingMethod Seed

            entity.HasData(
                new ShippingMethod()
                {
                    Id = 1,
                    Name = "Ground",
                    Description = "Shipping by land transport",
                    DisplayOrder = 1
                },

                new ShippingMethod()
                {
                    Id = 2,
                    Name = "Next Day Air",
                    Description = "The one day air shipping",
                    DisplayOrder = 2
                },

                new ShippingMethod()
                {
                    Id = 3,
                    Name = "2nd Day Air",
                    Description = "The two day air shipping",
                    DisplayOrder = 3
                }
                );
            #endregion
        }
    }
}
