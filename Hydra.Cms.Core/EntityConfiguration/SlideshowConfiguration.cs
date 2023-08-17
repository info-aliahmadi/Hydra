using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class SlideshowConfiguration : IEntityTypeConfiguration<Slideshow>
    {
        public void Configure(EntityTypeBuilder<Slideshow> builder)
        {
            builder.ToTable("Slideshow", "Cms");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Header).HasMaxLength(250);
            builder.Property(o => o.Description).HasMaxLength(500);


        }
    }
}
