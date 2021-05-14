using System.Threading.Tasks;
using GroceryStoreLibrary.Services.Repository;

namespace GroceryStoreLibrary.Services.Customer
{
    public class JsonCustomerService : ICustomerService
    {
        private readonly IJsonDataSource _dataSource;

        public JsonCustomerService(
            IJsonDataSource dataSource
            )
        {
            _dataSource = dataSource;
        }

        public async Task<Models.Customer[]> GetAllCustomers()
        {
            return await _dataSource.Read<Models.Customer>("customers", "");
        }

        public async Task<Models.Customer> GetCustomerById(int id)
        {
            return await _dataSource.ReadOne<Models.Customer>("customers", $"[?(@.id=={id})]");
        }

        public async Task<Models.Customer> AddCustomer(Models.Customer newCustomer)
        {
            return await _dataSource.Create("customers", newCustomer);
        }

        public async Task<bool> UpdateCustomer(Models.Customer customer)
        {
            var updated = await _dataSource.Create("customers", customer);
            return updated != null;
        }
    }
}
