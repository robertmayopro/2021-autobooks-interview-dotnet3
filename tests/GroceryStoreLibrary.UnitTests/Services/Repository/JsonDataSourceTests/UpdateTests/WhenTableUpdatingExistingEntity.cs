using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests.UpdateTests
{
    class WhenTableUpdatingExistingEntity : JsonDataSourceTestBase
    {

        [Test]
        public async Task ShouldReturnEntityWithNewId()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var customerToUpdate = new Models.Customer {Id = Ids.UPDATE_ID, Name = "Bob"};

            // Act
            var actual =await sut.Update(TableNames.CUSTOMERS, customerToUpdate);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(Ids.UPDATE_ID));
            Assert.That(actual.Name, Is.EqualTo("Bob"));
        }

        public async Task ShouldUpdateSuccessfullyInCollection()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var customerToUpdate = new Models.Customer { Id = Ids.UPDATE_ID, Name = "Bob" };

            // Act
            await sut.Update(TableNames.CUSTOMERS, customerToUpdate);
            var actual = await sut.ReadOne<Models.Customer>(TableNames.CUSTOMERS, $"[?(@.id=={Ids.UPDATE_ID})]");

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(Ids.UPDATE_ID));
            Assert.That(actual.Name, Is.EqualTo("Ellen"));
        }
    }
}