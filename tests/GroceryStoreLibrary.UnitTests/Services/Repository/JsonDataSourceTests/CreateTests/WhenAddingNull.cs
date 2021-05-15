using System;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests.CreateTests
{
    class WhenAddingNull : JsonDataSourceTestBase
    {
        [Test]
        public void ShouldThrowException()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();

            // Act, Assert
            Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Create(TableNames.CUSTOMERS, (Models.Customer)null),
                "Expected ArgumentNullException to be thrown.");
        }
    }
}