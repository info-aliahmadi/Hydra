using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.Cache
{
    public static class CacheStartup
    {
        public static void AddCacheProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            string cacheProvider = configuration.GetSection("CacheProvider").Value;

            var providerName = EFCacheProvider.ProviderName;

            services.AddEFCacheProvider();

            if (cacheProvider == "redis")
            {
                services.AddRedisCacheProvider(configuration, providerName);

            }
            else if (cacheProvider == "inmemory")
            {
                services.AddInMemoryCacheProvider(configuration, providerName);
            }
        }

    }
}