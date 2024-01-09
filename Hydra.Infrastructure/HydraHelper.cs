using Microsoft.AspNetCore.Http;

using System.Reflection;


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
            try
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
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
