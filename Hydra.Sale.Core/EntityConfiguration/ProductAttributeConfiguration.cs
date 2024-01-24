using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> entity)
        {
            entity.ToTable("ProductAttribute", "Sale");

            entity.HasIndex(e => e.DisplayOrder, "IX_Attribute_DisplayOrder");
            entity.HasIndex(e => e.AttributeType, "IX_Attribute_AttributeType");

            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
            entity.Property(e => e.Value)
            .IsRequired()
            .HasMaxLength(100);
            entity.Property(e => e.Description)
            .HasMaxLength(300);


            entity.HasData(new ProductAttribute()
            {
                Id = 1,
                DisplayOrder = 1,
                Name = "Blue",
                Value = "blue",
                AttributeType = AttributeType.Color
            }, new ProductAttribute()
            {
                Id = 2,
                DisplayOrder = 2,
                Name = "Red",
                Value = "red",
                AttributeType = AttributeType.Color
            }, new ProductAttribute()
            {
                Id = 3,
                DisplayOrder = 3,
                Name = "White",
                Value = "#fff",
                AttributeType = AttributeType.Color
            }, new ProductAttribute()
            {
                Id = 4,
                DisplayOrder = 4,
                Name = "Black",
                Value = "#000",
                AttributeType = AttributeType.Color
            }, new ProductAttribute()
            {
                Id = 5,
                DisplayOrder = 5,
                Name = "Small size",
                Value = "#Small",
                AttributeType = AttributeType.Size,
                Description = "Small Means S US Size"
            }, new ProductAttribute()
            {
                Id = 6,
                DisplayOrder = 6,
                Name = "Medium",
                Value = "#Medium",
                AttributeType = AttributeType.Size,
                Description = "Small Means M US Size"
            }, new ProductAttribute()
            {
                Id = 7,
                DisplayOrder = 7,
                Name = "Large",
                Value = "#Large",
                AttributeType = AttributeType.Size,
                Description = "Small Means XL US Size"
            });
        }
    }
}
