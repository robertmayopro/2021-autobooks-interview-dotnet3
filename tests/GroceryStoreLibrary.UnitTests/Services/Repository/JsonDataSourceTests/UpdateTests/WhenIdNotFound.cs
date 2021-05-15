using System.Collections.Generic;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests.UpdateTests
{
    class WhenIdNotFound : JsonDataSourceTestBase
    {
        [Test]
        public void ShouldThrowException()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var customerToUpdate = new Models.Customer { Id = Ids.INVALID_ID, Name = "Ellen" };


            // Act, Assert
            Assert.ThrowsAsync<KeyNotFoundException>(
                () => sut.Update(TableNames.CUSTOMERS, customerToUpdate),
                "Expected KeyNotFoundException to be thrown.");
        }
    }
}