using System.Threading.Tasks;
using GroceryStoreLibrary.Models;

namespace GroceryStoreLibrary.Services
{
    public interface ICustomerService
    {
        public Task<Customer[]> GetAllCustomers();
        public Task<Customer> GetCustomerById(int id);

        public Task<Customer> AddCustomer(Customer newCustomer);
        public Task<bool> UpdateCustomer(Customer customer);
    }
}
