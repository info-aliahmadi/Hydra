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


            builder.HasOne(x => x.PreviewImage).WithMany().HasForeignKey(x => x.PreviewImageId);

            builder.HasMany(e => e.Tags)
                   .WithMany(e => e.Articles)
                   .UsingEntity<ArticleTag>(
            l => l.HasOne<Tag>(e => e.Tag).WithMany(e => e.ArticleTags).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Cascade),
            r => r.HasOne<Article>(e => e.Article).WithMany(e => e.ArticleTags).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Cascade));


            builder.HasMany(e => e.Topics)
                   .WithMany(e => e.Articles)
                   .UsingEntity<ArticleTopic>(
            l => l.HasOne<Topic>(e => e.Topic).WithMany(e => e.ArticleTopics).HasForeignKey(x => x.TopicId).OnDelete(DeleteBehavior.Cascade),
            r => r.HasOne<Article>(e => e.Article).WithMany(e => e.ArticleTopics).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Cascade));

        }
    }
}
