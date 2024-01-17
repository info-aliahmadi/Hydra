using Hydra.Infrastructure;
using Hydra.Infrastructure.Configuration;
using Hydra.Migrations;
using Microsoft.EntityFrameworkCore;
//using Serilog;

//SerilogStartup.ConfigureLogging();


var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureApplicationServices(builder);


if (builder.Environment.IsProduction())
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Update Database
    builder.Services.AddDbContext<MigrationContext>((serviceProvider, options) =>
        options.UseSqlServer(connectionString), ServiceLifetime.Transient);
    try
    {
        using ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
        var context = serviceProvider.GetRequiredService<MigrationContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var loc = HydraHelper.GetApplicationDirectory() + @"\" + "AMigrationErrors.txt";
        var dateNow = DateTime.Now;
        string inform = dateNow + " | ConnectionString : " + connectionString + "- - - - - - - - - - - - - - - - - - - - - -" + ex.Source + ex.Message;
        File.WriteAllText(loc, inform);
    }
}
var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureRequestPipeline();


app.Run();

public partial class Program { }