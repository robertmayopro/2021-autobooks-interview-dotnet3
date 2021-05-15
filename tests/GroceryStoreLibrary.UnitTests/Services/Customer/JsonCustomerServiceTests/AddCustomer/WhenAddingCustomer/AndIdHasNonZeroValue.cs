using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Customer.JsonCustomerServiceTests.AddCustomer.WhenAddingCustomer
{
    class AndIdHasNonZeroValue : JsonCustomerServiceTestBase
    {
        [Test]
        public async Task ShouldIgnoreProvidedIdAndReturnCustomerWithNewId()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var newCustomer = new Models.Customer { Id = CustomerIds.INVALID_ID, Name = "Ellen" };

            // Act
            var actual = await sut.AddCustomer(newCustomer);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(CustomerIds.ADDED_ID));
            Assert.That(actual.Name, Is.EqualTo("Ellen"));
        }

        [Test]
        public async Task ShouldAddToCollectionSuccessfully()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var newCustomer = new Models.Customer { Id = CustomerIds.NEW_ID, Name = "Ellen" };

            // Act
            await sut.AddCustomer(newCustomer);
            var actual = await sut.GetCustomerById(CustomerIds.ADDED_ID);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(CustomerIds.ADDED_ID));
            Assert.That(actual.Name, Is.EqualTo("Ellen"));
        }
    }
}