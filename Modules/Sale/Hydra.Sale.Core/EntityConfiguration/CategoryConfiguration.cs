using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Category", "Sale");

            entity.HasIndex(e => e.DisplayOrder, "IX_Category_DisplayOrder");

            entity.HasIndex(e => e.ParentCategoryId, "IX_Category_ParentCategoryId");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.MetaDescription).HasMaxLength(300);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaTitle).HasMaxLength(250);
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(70);
            entity.Property(e => e.UpdatedOnUtc).HasPrecision(6);

            entity.HasOne(d => d.ParentCategory).WithMany()
            .HasForeignKey(d => d.ParentCategoryId)
            .HasConstraintName("FK_Category_Category");
        }
    }
}
