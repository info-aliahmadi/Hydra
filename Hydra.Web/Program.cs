using Hydra.Infrastructure.Configuration;
using Hydra.Infrastructure.Logs;
using Hydra.Migrations;
using Microsoft.EntityFrameworkCore;
using Serilog;



SerilogStartup.ConfigureLogging();

var connectionString = string.Empty;
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.ConfigureApplicationServices(builder);


    if (builder.Environment.IsProduction())
    {
        connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Update Database
        builder.Services.AddDbContext<MigrationContext>((serviceProvider, options) =>
            options.UseSqlServer(connectionString), ServiceLifetime.Transient);

        using ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
        var context = serviceProvider.GetRequiredService<MigrationContext>();
        context.Database.Migrate();

    }
    var app = builder.Build();
    app.ConfigureRequestPipeline();


    app.Run();
}
catch (Exception ex)
{
    string inform = DateTime.Now + " | ConnectionString : " + connectionString;
    Log.Fatal(ex, "Error during setup! " + inform);
}
finally
{
    Log.CloseAndFlush();
}
// Configure the HTTP request pipeline.


public partial class Program { }