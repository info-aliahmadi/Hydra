using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Product_Picture_Mapping");

            entity.ToTable("ProductPicture", "Sale");

            entity.HasIndex(e => e.PictureId, "IX_Product_Picture_Mapping_PictureId");

            entity.HasIndex(e => e.ProductId, "IX_Product_Picture_Mapping_ProductId");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductPicture_Product");
        }
    }
}
