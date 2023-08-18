using Hydra.Infrastructure.Security.EntityConfiguration;
using Hydra.Infrastructure.Setting.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Infrastructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : IdentityContext
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
            modelBuilder.ApplyConfiguration(new SettingConfiguration());

            #endregion
        }
        public DbSet<SiteSetting> Setting { get; set; }

    }
}
