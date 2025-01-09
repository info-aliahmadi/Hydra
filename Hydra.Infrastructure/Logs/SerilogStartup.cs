using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Hydra.Infrastructure.Logs
{
    public static class SerilogStartup
    {
        public static void AddSerilogConfig(this WebApplicationBuilder builder)
        {
            builder.Host.ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true);
            }).UseSerilog();


        }
        public static void ConfigureLogging()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true)
                .Build();
            var provider = configuration["Logging:Provider"];
            if (provider == "Elastic")
            {
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .Enrich.WithExceptionDetails()
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
                    .Enrich.WithProperty("Environment", environment)
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
            }
            else if (provider == "SQLight")
            {
                var rootDirecrtory = HydraHelper.GetApplicationDirectory() + "//";
                var dbName = configuration["Logging:Configuration:SQLight:DbName"];
                var tableName = configuration["Logging:Configuration:SQLight:TableName"];
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .Enrich.WithExceptionDetails()
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .WriteTo.SQLite(sqliteDbPath: rootDirecrtory + dbName, tableName: tableName, batchSize: 1)
                    .Enrich.WithProperty("Environment", environment)
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
            }
            else if (provider == "File")
            {
                var fileName = configuration["Logging:Configuration:File:FileName"];
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .Enrich.WithExceptionDetails()
                    .WriteTo.Debug()
                    .WriteTo.File(fileName, rollingInterval: RollingInterval.Day).CreateLogger();
            }
        }
        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string? environment)
        {
            return new ElasticsearchSinkOptions(new Uri(configuration["Logging:Configuration:Elastic:Uri"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name?.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UseSerilogExceptionHandler(this WebApplication app)
        {
            // All about exceptional handler and logging
            app.UseSerilogRequestLogging();
            app.UseStatusCodePages();

        }
    }
}
