using System.Collections.Generic;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Customer.CustomerServiceTests.UpdateCustomer.WhenUpdatingCustomer
{
    class AndIdIsNotInCollection : JsonCustomerServiceTestBase
    {
        [Test]
        public void ShouldThrowException()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var customerToUpdate = new Models.Customer { Id = CustomerIds.INVALID_ID, Name = "Bob" };


            // Act, Assert
            Assert.ThrowsAsync<KeyNotFoundException>(
                () => sut.UpdateCustomer(customerToUpdate),
                "Expected KeyNotFoundException to be thrown.");
        }
    }
}