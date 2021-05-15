using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GroceryStoreLibrary.Models;
using GroceryStoreLibrary.Services.Customer;

namespace GroceryStoreAPI.Controllers
{
    /// <summary>
    /// Actions for fetching/manipulating customer information.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Creates a new instance of the controller.
        /// </summary>
        /// <param name="customerService"></param>
        public CustomersController(
            ICustomerService customerService
            )
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <returns>Returns an array of <see cref="Customer"/> objects.</returns>
        [HttpGet]
        public async Task<Customer[]> GetAllCustomers()
        {
            return await _customerService.GetAllCustomers();
        }

        /// <summary>
        /// Get customer by customer ID.
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>Returns information for a single <see cref="Customer" />.</returns>
        [HttpGet("{id:int}")]
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerService.GetCustomerById(id);
        }

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="newCustomer">Customer to add</param>
        /// <returns>Returns information for the newly added <see cref="Customer" />.</returns>
        [HttpPost]
        public async Task<Customer> AddCustomer([FromBody] Customer newCustomer)
        {
            return await _customerService.AddCustomer(newCustomer);
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="updatedCustomer">Customer information to update</param>
        /// <returns>Returns true if a successful update occurred. Otherwise, false.</returns>
        [HttpPut]
        public async Task<bool> UpdateCustomer([FromBody] Customer updatedCustomer)
        {
            return await _customerService.UpdateCustomer(updatedCustomer);
        }
    }
}
