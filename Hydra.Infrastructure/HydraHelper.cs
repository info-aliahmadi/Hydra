using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest;

namespace Hydra.Infrastructure
{
    public static class HydraHelper
    {
        public static Assembly[] GetAssemblies(Func<string, bool> func, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll",
                searchOption)
                .Where(x => func(Path.GetFileName(x)))
                .Select(x => Assembly.LoadFrom(x));

            return assemblies.ToArray();
        }
        public static string GetCurrentDomain(HttpContext context)
        {
            return  $"{context.Request.Scheme}://{context.Request.Host.Value}/"; ;
        }
    }
}
