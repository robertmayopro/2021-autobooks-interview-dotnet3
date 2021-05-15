using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace GroceryStoreLibrary.Services.Customer
{
    [ExcludeFromCodeCoverage]
    public class SqliteCustomerService : ICustomerService
    {
        //TODO: Alternate implementation


        public Task<Models.Customer[]> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Customer> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Customer> AddCustomer(Models.Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(Models.Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
