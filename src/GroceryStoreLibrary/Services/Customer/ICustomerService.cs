using System.Threading.Tasks;

namespace GroceryStoreLibrary.Services.Customer
{
    /// <summary>
    /// Interface for customer-based operations
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all customers from the repository.
        /// </summary>
        /// <returns></returns>
        public Task<Models.Customer[]> GetAllCustomers();
        
        /// <summary>
        /// Gets a single customer by their customer ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Models.Customer> GetCustomerById(int id);

        /// <summary>
        /// Adds a new customer to the repository.
        /// </summary>
        /// <param name="newCustomer">The customer to add.</param>
        /// <returns></returns>
        public Task<Models.Customer> AddCustomer(Models.Customer newCustomer);
        
        /// <summary>
        /// Updates a customer within the repository
        /// </summary>
        /// <param name="customer">Customer information to update.</param>
        /// <returns></returns>
        public Task<bool> UpdateCustomer(Models.Customer customer);
    }
}
