using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article", "Cms");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Subject).HasMaxLength(250);


            builder.HasMany(o => o.Topics).WithMany(c => c.Articles);


            builder.HasMany(e => e.Tags)
                   .WithMany(e => e.Articles)
                   .UsingEntity<ArticleTag>(
            l => l.HasOne<Tag>(e => e.Tag).WithMany(e => e.ArticleTags).HasForeignKey(x=>x.TagId).OnDelete(DeleteBehavior.Cascade),
            r => r.HasOne<Article>(e => e.Article).WithMany(e => e.ArticleTags).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Cascade));

        }
    }
}
