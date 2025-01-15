using Hydra.Infrastructure.GeneralModels;
using Hydra.Infrastructure.Security.Constants;
using Hydra.Infrastructure.Security.Domain;
using Microsoft.AspNetCore.Http;

using System.Reflection;
using System.Security.Claims;


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
            return $"{context.Request.Scheme}://{context.Request.Host.Value}/"; ;
        }
        public static string GetApplicationDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
        public static string GetAvatarDirectory()
        {
            return Directory.GetCurrentDirectory() + @"\\images\\avatar\\";
        }
        public static string GetUploadsDirectory()
        {
            return Directory.GetCurrentDirectory() + @"\\uploads\\";
        }
        public static void DirectorySearch(string dir)
        {
            foreach (string f in Directory.GetFiles(dir))
            {
                Console.WriteLine(Path.GetFileName(f));
            }
            foreach (string d in Directory.GetDirectories(dir))
            {
                Console.WriteLine(Path.GetFileName(d));
                DirectorySearch(d);
            }
        }
        public static FileModel Base64FileToBytes(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            int indexOfSemiColon = input.IndexOf(";", StringComparison.OrdinalIgnoreCase);

            string dataLabel = input.Substring(0, indexOfSemiColon);

            string contentType = dataLabel.Split(':').Last();

            var startIndex = input.IndexOf("base64,", StringComparison.OrdinalIgnoreCase) + 7;

            var fileContents = input.Substring(startIndex);

            var bytes = Convert.FromBase64String(fileContents);

            return new FileModel()
            {
                ContentType = contentType,
                FileBytes = bytes
            };
        }

        public static string? GetUserId(this ClaimsPrincipal userPrincipal)
        {
            return userPrincipal.FindFirst("identity").Value;
        }
        public static string? GetIdentityName(this ClaimsPrincipal userPrincipal)
        {
            return userPrincipal.Identity.Name;
        }
        public static DateTime? GetExpiration(this ClaimsPrincipal userPrincipal)
        {
            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(userPrincipal.FindFirst(CustomClaimTypes.Expiration).Value)).DateTime;
        }

    }
}
