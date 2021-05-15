using System.Threading.Tasks;
using GroceryStoreLibrary.Services.Repository;

namespace GroceryStoreLibrary.Services.Customer
{
    /// <inheritdoc cref="ICustomerService" />
    public class CustomerService : ICustomerService
    {
        private readonly IDataSource _dataSource;

        public CustomerService(
            IDataSource dataSource
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
            var updated = await _dataSource.Update("customers", customer);
            return updated != null;
        }
    }
}
