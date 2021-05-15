using GroceryStoreLibrary.Services.Repository;
using Moq;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests
{
    abstract class JsonDataSourceTestBase
    {
        public static class TableNames
        {
            public const string CUSTOMERS = "customers";
            public const string GROCERY_STORES = "groceryStores";
        }

        public static class Ids
        {
            public const int NEW_ID = 0;
            public const int UPDATE_ID = 2;
            public const int ADDED_ID = 4;
            public const int INVALID_ID = 46;
            public const int GROCERY_STORE_ID = 37019;
        }

        protected virtual JsonDataSource SetUpSystemUnderTest()
        {
            var jsonFile = new Mock<IJsonFile>();
            jsonFile.Setup(x => x.LoadAsync())
                .ReturnsAsync(JObject.Parse(Utils.GetDatabaseSeedJson()));
            return new JsonDataSource(jsonFile.Object);
        }
    }
}