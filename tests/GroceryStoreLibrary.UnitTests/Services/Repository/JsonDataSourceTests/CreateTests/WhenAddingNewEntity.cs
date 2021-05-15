using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests.CreateTests
{
    class WhenAddingNewEntity : JsonDataSourceTestBase
    {

        [Test]
        public async Task ShouldReturnEntityWithNewId()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var newCustomer = new Models.Customer { Id = Ids.NEW_ID, Name = "Ellen" };

            // Act
            var actual = await sut.Create(TableNames.CUSTOMERS, newCustomer);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(Ids.ADDED_ID));
            Assert.That(actual.Name, Is.EqualTo("Ellen"));
        }


        [Test]
        public async Task ShouldAddSuccessfullyToCollection()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var newCustomer = new Models.Customer { Id = Ids.NEW_ID, Name = "Ellen" };

            // Act
            await sut.Create(TableNames.CUSTOMERS, newCustomer);
            var actual = await sut.ReadOne<Models.Customer>(TableNames.CUSTOMERS, $"[?(@.id=={Ids.ADDED_ID})]");

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(Ids.ADDED_ID));
            Assert.That(actual.Name, Is.EqualTo("Ellen"));
        }

        [Test]
        public async Task ShouldIgnoreIdAndAddToTheCollection()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var newCustomer = new Models.Customer { Id = Ids.INVALID_ID, Name = "Ellen" };

            // Act
            await sut.Create(TableNames.CUSTOMERS, newCustomer);
            var actual = await sut.ReadOne<Models.Customer>(TableNames.CUSTOMERS, $"[?(@.id=={Ids.ADDED_ID})]");

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(Ids.ADDED_ID));
            Assert.That(actual.Name, Is.EqualTo("Ellen"));
        }
    }
}