using Hydra.Infrastructure.Configuration;
using Hydra.Migrations;
using Microsoft.EntityFrameworkCore;
//using Serilog;
using System.Reflection;

//SerilogStartup.ConfigureLogging();

try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.ConfigureApplicationServices(builder);

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



    // Update Database
    builder.Services.AddDbContext<MigrationContext>((serviceProvider, options) =>
        options.UseSqlServer(connectionString), ServiceLifetime.Transient);


    using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
    {
        var context = serviceProvider.GetRequiredService<MigrationContext>();
        context.Database.Migrate();
    }


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.ConfigureRequestPipeline();


    app.Run();
}
catch (System.Exception ex)
{
    //Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
    //throw;
}
public partial class Program { }