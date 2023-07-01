using Hydra.Infrastructure.Security.Domain;
using Hydra.Infrastructure.Security.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentityContext : IdentityDbContext<User,Role,int,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Auth Builder

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());

            #endregion

        }
        public DbSet<Permission> Permissions { get; set; }

    }
}
