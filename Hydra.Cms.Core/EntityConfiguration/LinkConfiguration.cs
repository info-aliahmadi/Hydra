using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable("Link", "Cms");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Title).HasMaxLength(300);
            builder.Property(o => o.Url).HasMaxLength(300);
            builder.Property(o => o.Description).HasMaxLength(300);


        }
    }
}
