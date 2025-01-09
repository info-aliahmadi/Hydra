using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.AspNetCore.Builder;
using Hydra.Infrastructure.Cache;

namespace Hydra.Infrastructure.Data
{
    public static class DbContextStartup
    {
        public static void AddDbContextConfig(this WebApplicationBuilder builder)
        {

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // the default pool size in 1024 
            //Make sure that the maxPoolSize corresponds to your usage scenario;
            //if it is too low, DbContext instances will be constantly created and disposed,degrading performance.
            //Setting it too high may needlessly consume memory as
            //unused DbContext instances are maintained in the pool.

            builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
                options.UseSqlServer(connectionString
                             //,builder =>
                             //{
                             //    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                             //}
                             ).AddInterceptors(serviceProvider.GetRequiredService<SecondLevelCacheInterceptor>())

            , ServiceLifetime.Transient); // the default pool size in 1024 


            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddCacheProvider(builder.Configuration);

            //services.AddDataProtection().PersistKeysToDbContext<ApplicationDbContext>();

        }
        public static void AddAutoMigrate(this WebApplicationBuilder builder)
        {
            using ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}