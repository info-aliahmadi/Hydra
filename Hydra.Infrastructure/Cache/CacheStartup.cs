using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hydra.Infrastructure.Cache;

namespace Hydra.Infrastructure.Cache
{
    public static class CacheStartup
    {
        public static void AddCacheProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            string cacheProvider = configuration.GetSection("CacheProvider").Value;
            if (!string.IsNullOrEmpty(cacheProvider))
            {
                const string providerName = "DefaultHydra";
                services.AddEFCacheProvider(providerName);

                if (cacheProvider == "redis")
                {
                    services.AddRedisCacheProvider(configuration, providerName);

                }
                else if (cacheProvider == "inmemory")
                {
                    services.AddInMemoryCacheProvider(configuration, providerName);
                }
            }
            else
            {
                services.AddInMemoryEFCacheProvider();
            }
        }

    }
}