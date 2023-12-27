using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Crm.Core.EntityConfiguration.Subscribe
{
    public class SubscribeConfiguration : IEntityTypeConfiguration<Domain.Subscribe.Subscribe>
    {
        public void Configure(EntityTypeBuilder<Domain.Subscribe.Subscribe> entity)
        {
            entity.ToTable(nameof(Domain.Subscribe.Subscribe), "Cms");
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
