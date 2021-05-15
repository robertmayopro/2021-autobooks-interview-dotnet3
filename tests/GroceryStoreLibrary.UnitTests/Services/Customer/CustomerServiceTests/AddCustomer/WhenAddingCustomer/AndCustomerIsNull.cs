using System;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Customer.CustomerServiceTests.AddCustomer.WhenAddingCustomer
{
    class AndCustomerIsNull : JsonCustomerServiceTestBase
    {
        [Test]
        public void ShouldThrowException()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();

            // Act, Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => sut.AddCustomer(null), "Expected ArgumentNullException to be thrown.");
        }
    }
}