using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Customer.CustomerServiceTests.GetCustomerById
{
    class WhenGettingAnExistingCustomer : JsonCustomerServiceTestBase
    {
        [Test]
        public async Task ShouldRetrieveSuccessfully()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();

            // Act
            var actual = await sut.GetCustomerById(CustomerIds.EXISTING_ID);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(CustomerIds.EXISTING_ID));
            Assert.That(actual.Name, Is.EqualTo("Bob"));
        }
    }
}