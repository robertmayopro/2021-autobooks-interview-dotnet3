using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Customer.JsonCustomerServiceTests.UpdateCustomer.WhenUpdatingCustomer
{
    class AndIdIsInCollection : JsonCustomerServiceTestBase
    {
        [Test]
        public async Task ShouldUpdateSuccessfully()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var customerToUpdate = new Models.Customer { Id = CustomerIds.UPDATE_ID, Name = "Bob" };

            // Act
            var actual = await sut.UpdateCustomer(customerToUpdate);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public async Task ShouldAddToCollectionSuccessfully()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var customerToUpdate = new Models.Customer { Id = CustomerIds.UPDATE_ID, Name = "Bob" };

            // Act
            await sut.UpdateCustomer(customerToUpdate);
            var actual = await sut.GetAllCustomers();

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Length, Is.EqualTo(3));
        }

        [Test]
        public async Task ShouldBeAbleToRetrieveUpdatedCustomer()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var customerToUpdate = new Models.Customer { Id = CustomerIds.UPDATE_ID, Name = "Bob" };

            // Act
            await sut.UpdateCustomer(customerToUpdate);
            var actual = await sut.GetCustomerById(CustomerIds.UPDATE_ID);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(CustomerIds.UPDATE_ID));
            Assert.That(actual.Name, Is.EqualTo("Bob"));
        }
    }
}