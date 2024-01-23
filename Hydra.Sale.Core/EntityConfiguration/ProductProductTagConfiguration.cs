using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Cms.Core.EntityConfiguration
{
    public class ProductProductTagConfiguration : IEntityTypeConfiguration<ProductProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductProductTag> builder)
        {
            builder.ToTable("ProductProductTag", "Sale");

            builder.HasKey(p => new { p.ProductId, p.ProductTagId });


            builder.HasOne(x => x.Product).WithMany(x => x.ProductProductTags).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.ProductTag).WithMany(x => x.ProductProductTags).HasForeignKey(x => x.ProductTagId);
        }
    }
}
