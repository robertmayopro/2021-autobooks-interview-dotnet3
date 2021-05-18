using System.Threading.Tasks;
using GroceryStoreLibrary.Services.Repository;

namespace GroceryStoreLibrary.Services.Customer
{
    /// <inheritdoc cref="ICustomerService" />
    /// <remarks>This object has knowledge of how to retrieve/manipulate customers, given a JSON data source.</remarks>
    public class JsonCustomerService : ICustomerService
    {
        private readonly IDataSource _dataSource;

        /// <summary>
        /// Creates a new instance of <see cref="JsonCustomerService" />
        /// </summary>
        /// <param name="dataSource">The source of data (repository).</param>
        public JsonCustomerService(
            IJsonDataSource dataSource
            )
        {
            _dataSource = dataSource;
        }

        /// <inheritdoc cref="ICustomerService" />
        public async Task<Models.Customer[]> GetAllCustomers()
        {
            return await _dataSource.Read<Models.Customer>("customers", "");
        }

        /// <inheritdoc cref="ICustomerService" />
        public async Task<Models.Customer> GetCustomerById(int id)
        {
            return await _dataSource.ReadOne<Models.Customer>("customers", $"[?(@.id=={id})]");
        }

        /// <inheritdoc cref="ICustomerService" />
        public async Task<Models.Customer> AddCustomer(Models.Customer newCustomer)
        {
            return await _dataSource.Create("customers", newCustomer);
        }

        /// <inheritdoc cref="ICustomerService" />
        public async Task<bool> UpdateCustomer(Models.Customer customer)
        {
            var updated = await _dataSource.Update("customers", customer);
            return updated != null;
        }
    }
}
