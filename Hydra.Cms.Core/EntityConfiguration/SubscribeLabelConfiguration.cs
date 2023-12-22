using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Cms.Core.EntityConfiguration
{
    public class SubscribeLabelConfiguration : IEntityTypeConfiguration<SubscribeLabel>
    {
        public void Configure(EntityTypeBuilder<SubscribeLabel> entity)
        {
            entity.ToTable(nameof(SubscribeLabel), "Cms");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}
