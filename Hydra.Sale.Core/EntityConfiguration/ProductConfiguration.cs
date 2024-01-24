using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product", "Sale");

            entity.HasIndex(e => new { e.Published, e.Deleted, e.Id }, "IX_Product_Deleted_and_Published");

            entity.Property(e => e.AdminComment).HasMaxLength(300);
            entity.Property(e => e.AvailableEndDateTimeUtc).HasPrecision(6);
            entity.Property(e => e.AvailableStartDateTimeUtc).HasPrecision(6);
            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.UpdatedOnUtc).HasPrecision(6);
            entity.Property(e => e.MarkAsNewEndDateTimeUtc).HasPrecision(6);
            entity.Property(e => e.MarkAsNewStartDateTimeUtc).HasPrecision(6);
            entity.Property(e => e.MetaDescription).HasMaxLength(300);
            entity.Property(e => e.MetaKeywords).HasMaxLength(300);
            entity.Property(e => e.MetaTitle).HasMaxLength(100);
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
            entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ShortDescription).HasMaxLength(300);

            entity.HasOne(d => d.DeliveryDate).WithMany(p => p.Products)
            .HasForeignKey(d => d.DeliveryDateId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Product_DeliveryDate");

            entity.HasOne(d => d.Currency).WithMany(p => p.Products)
            .HasForeignKey(d => d.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Product_Currency");

            entity.HasOne(d => d.TaxCategory).WithMany(p => p.Products)
            .HasForeignKey(d => d.TaxCategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Product_TaxCategory");

            entity.HasOne(d => d.CreateUser).WithMany()
            .HasForeignKey(d => d.CreateUserId)
            .HasConstraintName("FK_Product_CreateUser");

            entity.HasOne(d => d.UpdateUser).WithMany()
            .HasForeignKey(d => d.UpdateUserId)
            .HasConstraintName("FK_Product_UpdateUser");

            //entity.HasMany(d => d.ProductTags).WithMany(p => p.Products)
            //.UsingEntity<Dictionary<string, object>>(
            //    "ProductProductTag",
            //    r => r.HasOne<ProductTag>().WithMany()
            //        .HasForeignKey("ProductTagId")
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_ProductProductTag_ProductTag"),
            //    l => l.HasOne<Product>().WithMany()
            //        .HasForeignKey("ProductId")
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_ProductProductTag_Product"),
            //    j =>
            //    {
            //        j.HasKey("ProductId", "ProductTagId").HasName("PK_Product_ProductTag_Mapping");
            //        j.ToTable("ProductProductTag", "Sale");
            //        j.HasIndex(new[] { "ProductTagId" }, "IX_Product_ProductTag_Mapping_ProductTag_Id");
            //        j.HasIndex(new[] { "ProductId" }, "IX_Product_ProductTag_Mapping_Product_Id");
            //    });
        }
    }
}
