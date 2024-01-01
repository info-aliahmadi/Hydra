using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> entity)
        {
            entity.ToTable("ProductReview", "Sale");

            entity.HasIndex(e => e.UserId, "IX_ProductReview_CustomerId");

            entity.HasIndex(e => e.ProductId, "IX_ProductReview_ProductId");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.ReplyText).HasMaxLength(300);
            entity.Property(e => e.ReviewText).HasMaxLength(300);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductReview_Product");

            entity.HasOne(d => d.User).WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductReview_User");
        }
    }
}
