using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> entity)
        {
            entity.ToTable("Manufacturer", "Sale");

            entity.HasIndex(e => e.DisplayOrder, "IX_Manufacturer_DisplayOrder");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.MetaDescription).HasMaxLength(300);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaTitle).HasMaxLength(250);
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(70);
            entity.Property(e => e.UpdatedOnUtc).HasPrecision(6);


            entity.HasData(new Manufacturer()
            {
                Id = 1,
                DisplayOrder = 1,
                Name = "Manufacturer 1",
                MetaDescription = "MetaDescription",
                MetaKeywords = "MetaKeywords",
                MetaTitle = "Title",
                CreatedOnUtc = DateTime.Parse("2024-01-10 10:58:14.7398970"),
                Deleted = false,
                Description = "Description of Category 1",
                Published = true
            }, new Manufacturer()
            {
                Id = 2,
                DisplayOrder = 2,
                Name = "Manufacturer 2",
                MetaDescription = "MetaDescription",
                MetaKeywords = "MetaKeywords",
                MetaTitle = "Title",
                CreatedOnUtc = DateTime.Parse("2024-01-10 10:58:14.7398970"),
                Deleted = false,
                Description = "Description of Category 2",
                Published = true
            });

        }
    }
}
