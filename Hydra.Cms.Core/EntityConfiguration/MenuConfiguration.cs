using Hydra.Cms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu", "Cms");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Title).HasMaxLength(100);

            builder.Property(o => o.Url).HasMaxLength(300);

            builder.HasData(new Menu()
            {
                Id = 1,
                Order = 0,
                Title = "About",
                Url = "/About",
                UserId = 1,
            },
            new Menu()
            {
                Id = 2,
                Order = 1,
                Title = "Service",
                Url = "/Service",
                UserId = 1,
            },
            new Menu()
            {
                Id = 3,
                Order = 2,
                Title = "Pricing",
                Url = "/Pricing",
                UserId = 1,
            },
            new Menu()
            {
                Id = 4,
                Order = 3,
                Title = "Contact",
                Url = "/Contact",
                UserId = 1,
            },
            new Menu()
            {
                Id = 5,
                Order = 4,
                Title = "Blog",
                Url = "/Blog",
                UserId = 1,
            });

        }
    }
}
