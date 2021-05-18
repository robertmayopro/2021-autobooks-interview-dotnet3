using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Customer.JsonCustomerServiceTests.GetCustomerById
{
    class WhenGettingANonExistingCustomer : JsonCustomerServiceTestBase
    {
        [Test]
        public async Task ShouldReturnNull()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();

            // Act
            var actual = await sut.GetCustomerById(CustomerIds.INVALID_ID);

            // Assert
            Assert.That(actual, Is.Null);
        }
    }
}