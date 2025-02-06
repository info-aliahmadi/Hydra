using Hydra.Auth.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Auth.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User","Auth");

            builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            builder.Property(o => o.UserName).HasMaxLength(256);
            builder.Property(o => o.NormalizedUserName).HasMaxLength(256);
            builder.Property(o => o.Email).HasMaxLength(256);
            builder.Property(o => o.NormalizedEmail).HasMaxLength(256);
            builder.Property(o => o.Name).HasMaxLength(50);
            builder.Property(o => o.Avatar).HasMaxLength(50);
            builder.Property(o => o.DefaultLanguage).HasMaxLength(6);
            builder.Property(o => o.DefaultTheme).HasMaxLength(10);
            builder.Property(o => o.PhoneNumber).HasMaxLength(20);
            builder.Property(o => o.SecurityStamp).HasMaxLength(50);
            builder.Property(o => o.PasswordHash).HasMaxLength(100);
            builder.Property(o => o.ConcurrencyStamp).HasMaxLength(50);

        }
    }
}
