using Hydra.Infrastructure.Security;
using Hydra.Kernel;
using Hydra.Kernel.Localization.EntityConfiguration;
using Hydra.Kernel.Setting.Domain;
using Hydra.Kernel.Setting.EntityConfiguration;
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

            modelBuilder.ApplyConfiguration(new SiteSettingConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            #region Configuration Builder

            var assembliesList = HydraHelper.GetAssemblies(x => x.StartsWith("Hydra") && x.Contains("Core"));

            foreach (var assembly in assembliesList)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            }

            #endregion
        }
        public DbSet<SiteSetting> Setting { get; set; }
        //public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    }
}
