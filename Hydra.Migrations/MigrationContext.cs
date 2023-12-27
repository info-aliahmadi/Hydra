using Hydra.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Migrations
{
    public class MigrationContext : ApplicationDbContext
    {
        public MigrationContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
