using System;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests.ReadOneTests
{
    class WhenTableDoesNotExist : JsonDataSourceTestBase
    {
        [Test]
        public void ShouldThrowException()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();

            // Act, Assert
            Assert.ThrowsAsync<ArgumentException>(
                () => sut.ReadOne<GroceryStore>(TableNames.GROCERY_STORES, $"[?(@.id == {Ids.GROCERY_STORE_ID})]"),
                "Expected ArgumentException to be thrown.");
        }
    }
}