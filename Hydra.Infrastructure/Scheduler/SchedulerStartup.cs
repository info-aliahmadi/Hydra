using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace Hydra.Infrastructure.Social
{
    public static class Scheduler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UseScheduler(this WebApplication app)
        {

            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            GlobalConfiguration.Configuration.UseColouredConsoleLogProvider();

            using (new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started...");
            }
        }
    }
}