using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class LinkSectionConfiguration : IEntityTypeConfiguration<LinkSection>
    {
        public void Configure(EntityTypeBuilder<LinkSection> builder)
        {
            builder.ToTable("LinkSection", "Cms");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Title).HasMaxLength(300);

            builder.HasData(new LinkSection()
            {
                Id = 1,
                Title = "Categories",
                Key = "Categories",
                IsVisible = true,
            }, new LinkSection()
            {
                Id = 2,
                Title = "Recent Post",
                Key = "RecentPosts",
                IsVisible = true,
            });
        }
    }
}
