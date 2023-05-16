using Hydra.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Cms.Api.Endpoints
{
    public class OrdersModule : IModule
    {
        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            //services.AddSingleton(new OrderConfig());
            //services.AddScoped<IOrdersRepository, OrdersRepository>();
            //services.AddScoped<ICustomersRepository, CustomersRepository>();
            //services.AddScoped<IPayment, PaymentService>();
            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/orders", () =>
            {
                return "Hello Orders";
            });

            endpoints.MapPost("/orders", () =>
            {
                return "Hello World!";
            }).AllowAnonymous();

            return endpoints;
        }

    }
}
