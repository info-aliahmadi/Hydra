using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Page", "Cms");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.PageTitle).HasMaxLength(250);
            builder.Property(o => o.Subject).HasMaxLength(250);



            builder.HasMany(e => e.Tags)
                   .WithMany(e => e.Pages)
                   .UsingEntity<PageTag>(
            l => l.HasOne<Tag>(e => e.Tag).WithMany(e => e.PageTags).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Cascade),
            r => r.HasOne<Page>(e => e.Page).WithMany(e => e.PageTags).HasForeignKey(x => x.PageId).OnDelete(DeleteBehavior.Cascade));

        }
    }
}
