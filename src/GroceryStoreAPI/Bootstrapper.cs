using System.IO;
using System.Reflection;
using GroceryStoreLibrary.Services.Customer;
using GroceryStoreLibrary.Services.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryStoreAPI
{
    internal static class Bootstrapper
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            IJsonFile jsonFile = GetDatabaseFile();

            services.AddSingleton<IJsonFile>(jsonFile);
            services.AddSingleton<IJsonDataSource, JsonDataSource>();
            services.AddSingleton<ICustomerService, JsonCustomerService>();
        }


        private static JsonFile GetDatabaseFile()
        {
            string binDir = GetBinDir();
            string fileName = "database.json";
            string filePath = Path.Combine(binDir, fileName);

            JsonFile config = new JsonFile(filePath);
            return config;
        }


        private static string GetBinDir()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

    }
}
