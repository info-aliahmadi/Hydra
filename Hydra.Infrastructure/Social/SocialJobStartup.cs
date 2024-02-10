using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace Hydra.Infrastructure.Social
{
    public static class SocialJobStartup
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UseSocialJob(this WebApplication app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");


        }
    }

}