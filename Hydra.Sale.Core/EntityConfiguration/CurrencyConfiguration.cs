using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> entity)
        {
            entity.ToTable("Currency", "Sale");

            entity.HasIndex(e => e.DisplayOrder, "IX_Currency_DisplayOrder");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.CurrencyCode)
            .IsRequired()
            .HasMaxLength(5);
            entity.Property(e => e.CustomFormatting).HasMaxLength(50);
            entity.Property(e => e.DisplayLocale).HasMaxLength(50);
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedOnUtc).HasPrecision(6);

            #region Currency Seed

            entity.HasData(
                new Currency()
                {
                    Id = 1,
                    Name = "US Dollar",
                    CurrencyCode = "USD",
                    DisplayLocale = "en-US",
                    CustomFormatting = string.Empty,
                    Rate = Convert.ToDecimal(1.0000),
                    LimitedToStores = false,
                    Published = true,
                    DisplayOrder = 1,
                    CreatedOnUtc = DateTime.Parse("2024-01-10 10:58:14.7398970"),
                    UpdatedOnUtc = DateTime.Parse("2024-01-10 10:58:14.7398970"),
                    RoundingTypeId = 0
                },
                new Currency()
                {
                    Id = 2,
                    Name = "Euro",
                    CurrencyCode = "EUR",
                    DisplayLocale = string.Empty,
                    CustomFormatting = "€0.00",
                    Rate = Convert.ToDecimal(0.8600),
                    LimitedToStores = false,
                    Published = true,
                    DisplayOrder = 2,
                    CreatedOnUtc = DateTime.Parse("2024-01-10 10:58:14.7398970"),
                    UpdatedOnUtc = DateTime.Parse("2024-01-10 10:58:14.7398970"),
                    RoundingTypeId = 0
                },
                new Currency()
                {
                    Id = 3,
                    Name = "Iranian",
                    CurrencyCode = "Rial",
                    DisplayLocale = "fa-IR",
                    CustomFormatting = string.Empty,
                    Rate = Convert.ToDecimal(1.0000),
                    LimitedToStores = false,
                    Published = true,
                    DisplayOrder = 3,
                    CreatedOnUtc = DateTime.Parse("2024-01-10 10:58:14.7398970"),
                    UpdatedOnUtc = DateTime.Parse("2024-01-10 10:58:14.7398970"),
                    RoundingTypeId = 0
                }
                );

            #endregion
        }
    }
}
