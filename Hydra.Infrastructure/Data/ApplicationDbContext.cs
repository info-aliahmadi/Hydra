using Hydra.Infrastructure.Security;
using Hydra.Infrastructure.Security.EntityConfiguration;
using Hydra.Infrastructure.Setting.Domain;
using Hydra.Infrastructure.Setting.EntityConfiguration;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Infrastructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : IdentityContext //, IDataProtectionKeyContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configuration Builder

            var assembliesList = HydraHelper.GetAssemblies(x => x.StartsWith("Hydra") && x.Contains("Core"));

            foreach (var assembly in assembliesList)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            }
            modelBuilder.ApplyConfiguration(new SiteSettingConfiguration());

            #endregion
        }
        public DbSet<SiteSetting> Setting { get; set; }
        //public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    }
}
