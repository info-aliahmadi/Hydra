using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Cms.Core.EntityConfiguration
{
    public class PageTagConfiguration : IEntityTypeConfiguration<PageTag>
    {
        public void Configure(EntityTypeBuilder<PageTag> builder)
        {
            builder.ToTable("PageTag", "Cms");

            builder.HasKey(p => new { p.TagId, p.PageId });


            builder.HasOne(x => x.Page).WithMany(x => x.PageTags).HasForeignKey(x => x.PageId);

            builder.HasOne(x => x.Tag).WithMany(x => x.PageTags).HasForeignKey(x => x.TagId);
        }
    }
}
