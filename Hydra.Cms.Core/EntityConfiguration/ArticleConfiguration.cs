using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article", "Cms");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Subject).HasMaxLength(250);


            builder.HasMany(o => o.Topics).WithMany(c=>c.Articles);

            builder.HasMany(o => o.Tags).WithMany(c => c.Articles);

        }
    }
}
