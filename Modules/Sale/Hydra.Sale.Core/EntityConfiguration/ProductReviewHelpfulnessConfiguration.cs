using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductReviewHelpfulnessConfiguration : IEntityTypeConfiguration<ProductReviewHelpfulness>
    {
        public void Configure(EntityTypeBuilder<ProductReviewHelpfulness> entity)
        {
            entity.ToTable("ProductReviewHelpfulness", "Sale");

            entity.HasIndex(e => e.ProductReviewId, "IX_ProductReviewHelpfulness_ProductReviewId");

            entity.HasOne(d => d.ProductReview).WithMany(p => p.ProductReviewHelpfulnesses)
            .HasForeignKey(d => d.ProductReviewId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductReviewHelpfulness_ProductReview");

            entity.HasOne(d => d.User).WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductReviewHelpfulness_User");
        }
    }
}
