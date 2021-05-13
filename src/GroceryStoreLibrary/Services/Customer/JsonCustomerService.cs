using System.Threading.Tasks;
using GroceryStoreLibrary.Models;
using GroceryStoreLibrary.Services.Repository;

namespace GroceryStoreLibrary.Services
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

        public async Task<Customer[]> GetAllCustomers()
        {
            return await _dataSource.Read<Customer>("$.customers");
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _dataSource.ReadOne<Customer>("$.customers[?(@.id=={id)]");
        }

        public async Task<Customer> AddCustomer(Customer newCustomer)
        {
            return await _dataSource.Create("customers", newCustomer);
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var updated = await _dataSource.Create("customers", customer);
            return updated != null;
        }
    }
}
