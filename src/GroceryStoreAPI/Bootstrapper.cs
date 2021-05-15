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
            IJsonAccess jsonFile = GetDatabaseFile();

            services.AddSingleton<IJsonAccess>(jsonFile);
            services.AddSingleton<IDataSource, JsonDataSource>();
            services.AddSingleton<ICustomerService, CustomerService>();
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
