using Hydra.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.ModuleExtension
{


    public static class ModuleExtensions
    {
        // this could also be added into the DI container
        static readonly List<IModule> registeredModules = new List<IModule>();

        public static IServiceCollection AddModulesService(this IServiceCollection services)
        {
            var modules = DiscoverModules();
            foreach (var module in modules)
            {
                module.RegisterModules(services);
                registeredModules.Add(module);
            }

            return services;
        }

        public static WebApplication MapModulesEndpoints(this WebApplication app)
        {
            foreach (var module in registeredModules)
            {
                module.MapEndpoints(app);
            }
            return app;
        }

        private static IEnumerable<IModule> DiscoverModules()
        {
            var modulesList = new List<IModule>();
            var assembliesList = HydraHelper.GetAssemblies(x => x.StartsWith("Hydra") && x.Contains("Api"));
            foreach (var assembly in assembliesList)
            {
                modulesList.AddRange(assembly
                .GetTypes()
                .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
                .Select(Activator.CreateInstance)
                .Cast<IModule>());
            }

            return modulesList;
            //var modules = typeof(IModule).Assembly
            //    .GetTypes()
            //    .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            //    .Select(Activator.CreateInstance)
            //    .Cast<IModule>();
        }
    }
}
