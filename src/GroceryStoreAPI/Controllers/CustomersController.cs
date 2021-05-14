using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GroceryStoreLibrary.Models;
using GroceryStoreLibrary.Services;
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
    }
}
