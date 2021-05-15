using System;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests.ReadTests
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
                () => sut.Read<GroceryStore>(TableNames.GROCERY_STORES, $"[?(@.id == {Ids.GROCERY_STORE_ID})]"),
                "Expected ArgumentException to be thrown.");
        }
    }
}