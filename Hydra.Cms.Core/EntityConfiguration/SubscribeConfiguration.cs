using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Cms.Core.EntityConfiguration
{
    public class SubscribeConfiguration : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> entity)
        {
            entity.ToTable(nameof(Subscribe), "Cms");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.InsertDate).HasColumnType("datetime");

            entity.HasOne(d => d.SubscribeLabel).WithMany(p => p.Subscribes)
            .HasForeignKey(d => d.SubscribeLabelId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Subscribe_SubscribeLabel");
        }
    }
}
