using Hydra.Infrastructure.Configuration;
using Hydra.Infrastructure.Logs;
using Serilog;



SerilogStartup.ConfigureLogging();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.ConfigureApplicationServices(builder);

    var app = builder.Build();

    app.ConfigureRequestPipeline();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Error during setup! ");
}
finally
{
    Log.CloseAndFlush();
}



public partial class Program { }