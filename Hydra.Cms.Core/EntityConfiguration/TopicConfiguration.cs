using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topic", "Cms");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Title).HasMaxLength(100);


        }
    }
}
