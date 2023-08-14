using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Cms.Core.EntityConfiguration
{
    public class ArticleTopicConfiguration : IEntityTypeConfiguration<ArticleTopic>
    {
        public void Configure(EntityTypeBuilder<ArticleTopic> builder)
        {
            builder.ToTable("ArticleTopic", "Cms");

            builder.HasKey(p => new { p.TopicId, p.ArticleId });

            builder.HasOne(x => x.Article).WithMany(x => x.ArticleTopics).HasForeignKey(x => x.ArticleId);

            builder.HasOne(x => x.Topic).WithMany(x => x.ArticleTopics).HasForeignKey(x => x.TopicId);
        }
    }
}
