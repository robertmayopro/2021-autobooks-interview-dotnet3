﻿using System;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests.UpdateTests
{
    class WhenTableDoesNotExist : JsonDataSourceTestBase
    {
        [Test]
        public void ShouldThrowException()
        {
            // Arrange
            var sut = SetUpSystemUnderTest();
            var groceryStore = new GroceryStore { Id = Ids.GROCERY_STORE_ID, Name = "French Toast Emergency", Location = "Baltimore" };

            // Act, Assert
            Assert.ThrowsAsync<ArgumentException>(
                () => sut.Update(TableNames.GROCERY_STORES, groceryStore),
                "Expected ArgumentException to be thrown.");
        }
    }
}