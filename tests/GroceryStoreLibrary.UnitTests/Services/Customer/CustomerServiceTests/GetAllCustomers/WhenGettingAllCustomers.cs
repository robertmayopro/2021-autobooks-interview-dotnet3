using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Customer.CustomerServiceTests.GetAllCustomers
{
    class WhenGettingAllCustomers : JsonCustomerServiceTestBase
    {
        [Test]
        public async Task ShouldRetrieveAllCustomersSuccessfully()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();

            // Act
            var actual = await sut.GetAllCustomers();

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Length, Is.EqualTo(3));
            Assert.That(actual[0], Is.Not.Null);
            Assert.That(actual[0].Id, Is.EqualTo(1));
            Assert.That(actual[0].Name, Is.EqualTo("Bob"));
            Assert.That(actual[1], Is.Not.Null);
            Assert.That(actual[1].Id, Is.EqualTo(2));
            Assert.That(actual[1].Name, Is.EqualTo("Mary"));
            Assert.That(actual[2], Is.Not.Null);
            Assert.That(actual[2].Id, Is.EqualTo(3));
            Assert.That(actual[2].Name, Is.EqualTo("Joe"));
        }
    }
}