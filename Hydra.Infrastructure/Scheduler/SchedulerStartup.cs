using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.Scheduler
{
    public static class Scheduler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void AddScheduler(this IServiceCollection services,
            IConfiguration configuration)
        {

            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            GlobalConfiguration.Configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connectionString);

            using (new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started...");
            }

            // Only Once
            //var jobId = BackgroundJob.Schedule(
            //                () => Console.WriteLine("Delayed!"),
            //                TimeSpan.FromDays(7));

            //// every day
            //RecurringJob.AddOrUpdate(
            //            "myrecurringjob",
            //            () => Console.WriteLine("Recurring!"),
            //            Cron.Daily);

            // conditionally
            //BackgroundJob.ContinueJobWith(
            //            jobId,
            //            () => Console.WriteLine("Continuation!"));


        }
    }
}