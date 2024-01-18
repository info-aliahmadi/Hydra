using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> entity)
        {
            entity.ToTable("Discount", "Sale");

            entity.Property(e => e.CouponCode).HasMaxLength(100);
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.EndDateUtc).HasPrecision(6);
            entity.Property(e => e.MaximumDiscountAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200);
            entity.Property(e => e.StartDateUtc).HasPrecision(6);

            entity.HasMany(d => d.Categories).WithMany(p => p.Discounts)
            .UsingEntity<Dictionary<string, object>>(
                "DiscountCategory",
                r => r.HasOne<Category>().WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DiscountCategory_Category"),
                l => l.HasOne<Discount>().WithMany()
                    .HasForeignKey("DiscountId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DiscountCategory_Discount"),
                j =>
                {
                    j.HasKey("DiscountId", "CategoryId").HasName("PK_Discount_AppliedToCategories");
                    j.ToTable("DiscountCategory", "Sale");
                    j.HasIndex(new[] { "CategoryId" }, "IX_Discount_AppliedToCategories_Category_Id");
                    j.HasIndex(new[] { "DiscountId" }, "IX_Discount_AppliedToCategories_Discount_Id");
                });

            entity.HasMany(d => d.Manufacturers).WithMany(p => p.Discounts)
            .UsingEntity<Dictionary<string, object>>(
                "DiscountManufacturer",
                r => r.HasOne<Manufacturer>().WithMany()
                    .HasForeignKey("ManufacturerId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DiscountManufacturer_Manufacturer"),
                l => l.HasOne<Discount>().WithMany()
                    .HasForeignKey("DiscountId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DiscountManufacturer_Discount"),
                j =>
                {
                    j.HasKey("DiscountId", "ManufacturerId").HasName("PK_Discount_AppliedToManufacturers");
                    j.ToTable("DiscountManufacturer", "Sale");
                    j.HasIndex(new[] { "DiscountId" }, "IX_Discount_AppliedToManufacturers_Discount_Id");
                    j.HasIndex(new[] { "ManufacturerId" }, "IX_Discount_AppliedToManufacturers_Manufacturer_Id");
                });

            entity.HasMany(d => d.Products).WithMany(p => p.Discounts)
            .UsingEntity<Dictionary<string, object>>(
                "DiscountProduct",
                r => r.HasOne<Product>().WithMany()
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DiscountProduct_Product"),
                l => l.HasOne<Discount>().WithMany()
                    .HasForeignKey("DiscountId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DiscountProduct_Discount"),
                j =>
                {
                    j.HasKey("DiscountId", "ProductId").HasName("PK_Discount_AppliedToProducts");
                    j.ToTable("DiscountProduct", "Sale");
                    j.HasIndex(new[] { "DiscountId" }, "IX_Discount_AppliedToProducts_Discount_Id");
                    j.HasIndex(new[] { "ProductId" }, "IX_Discount_AppliedToProducts_Product_Id");
                });


            entity.HasData(new Discount()
            {
                Id = 1,
                Name = "Discount 1",
                CouponCode = "CoponCode1",
                AdminComment = "AdminComment",
                DiscountTypeId = DiscountType.AssignedToCategories,
                UsePercentage = true,
                DiscountPercentage = 4,
                DiscountAmount = 0,
                RequiresCouponCode = true,
                DiscountLimitationId = DiscountLimitationType.Unlimited,
                LimitationTimes = 1,
                IsActive = true


            }, new Discount()
            {
                Id = 2,
                Name = "Discount 2",
                CouponCode = "CoponCode2",
                AdminComment = "AdminComment",
                DiscountTypeId = DiscountType.AssignedToCategories,
                UsePercentage = true,
                DiscountPercentage = 6,
                DiscountAmount = 0,
                RequiresCouponCode = true,
                DiscountLimitationId = DiscountLimitationType.NTimesOnly,
                LimitationTimes = 1,
                IsActive = true
            });

        }
    }
}
