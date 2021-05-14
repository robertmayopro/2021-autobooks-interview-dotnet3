using System.IO;
using System.Reflection;
using GroceryStoreLibrary.Services;
using GroceryStoreLibrary.Services.Customer;
using GroceryStoreLibrary.Services.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryStoreAPI
{
    internal static class Bootstrapper
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            IJsonDataSource jasonDataSource = GetDatabaseFile();

            services.AddSingleton<IJsonDataSource>(jasonDataSource);
            services.AddSingleton<ICustomerService, JsonCustomerService>();
        }


        private static JsonFileDataSource GetDatabaseFile()
        {

            string binDir = GetBinDir();
            string fileName = "database.json";
            string filePath = Path.Combine(binDir, fileName);

            JsonFileDataSource config = new JsonFileDataSource(filePath);
            return config;
        }


        private static string GetBinDir()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

    }
}
