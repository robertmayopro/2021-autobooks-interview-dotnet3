using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GroceryStoreLibrary.Models;
using GroceryStoreLibrary.Services.Customer;

namespace GroceryStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(
            ICustomerService customerService
            )
        {
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<Customer[]> GetAllCustomers()
        {
            return await _customerService.GetAllCustomers();
        }

        [HttpGet("{id:int}")]
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerService.GetCustomerById(id);
        }

        [HttpPost]
        public async Task<Customer> CreateCustomer([FromBody] Customer newCustomer)
        {
            return await _customerService.AddCustomer(newCustomer);
        }

        [HttpPut]
        public async Task<bool> UpdateCustomer([FromBody] Customer updatedCustomer)
        {
            return await _customerService.UpdateCustomer(updatedCustomer);
        }
    }
}
