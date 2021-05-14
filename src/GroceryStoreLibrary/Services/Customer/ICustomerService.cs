using System.Threading.Tasks;

namespace GroceryStoreLibrary.Services.Customer
{
    public interface ICustomerService
    {
        public Task<Models.Customer[]> GetAllCustomers();
        public Task<Models.Customer> GetCustomerById(int id);

        public Task<Models.Customer> AddCustomer(Models.Customer newCustomer);
        public Task<bool> UpdateCustomer(Models.Customer customer);
    }
}
