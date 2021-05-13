using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GroceryStoreLibrary.Models;
using GroceryStoreLibrary.Services;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<Customer[]> Get()
        {
            return await _customerService.GetAllCustomers();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<Customer> Get(int id)
        {
            return await _customerService.GetCustomerById(id);
        }
    }
}
