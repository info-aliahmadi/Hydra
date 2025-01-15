using Hydra.Infrastructure.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Hydra.Infrastructure.localization
{
    public static class LocalizationStartup
    {
        /// <summary>
        /// Configure the application HTTP request pipeline
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseLocalization(this WebApplication app)
        {
            // Configure the HTTP request pipeline.

            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo(CultureInfoTypes.ENGLISH_US),
                new CultureInfo(CultureInfoTypes.ENGLISH_GB),
                new CultureInfo(CultureInfoTypes.GERMAN_DE),
                new CultureInfo(CultureInfoTypes.FRENCH),
                new CultureInfo(CultureInfoTypes.ARABIC),
                new CultureInfo(CultureInfoTypes.FARSI)
            };

            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(CultureInfoTypes.ENGLISH_US),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider()
                    {
                        QueryStringKey = "lang",
                        UIQueryStringKey ="ui-lang"

                    },
                    new AcceptLanguageHeaderRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                }
            };

            /*  If you want use rout culture uncomment code bellow  */
            //var requestProvider = new RouteDataRequestCultureProvider();
            //requestLocalizationOptions.RequestCultureProviders.Insert(0, requestProvider);

            app.UseRequestLocalization(requestLocalizationOptions);

            /*  If you want use rout culture uncomment code bellow  */
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(name: "default", pattern: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");
            //});

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddlocalizationConfig(this IServiceCollection services)
        {

            services.AddLocalization(options => options.ResourcesPath = "Resources");

        }
    }

}