using Hydra.Crm.Core.Domain.Subscribe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Crm.Core.EntityConfiguration.Subscribe
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
