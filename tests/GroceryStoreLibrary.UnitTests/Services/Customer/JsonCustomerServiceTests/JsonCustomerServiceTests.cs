using GroceryStoreLibrary.Services.Customer;
using GroceryStoreLibrary.Services.Repository;
using Moq;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.UnitTests.Services.Customer.JsonCustomerServiceTests
{
    abstract class JsonCustomerServiceTestBase
    {
        public static class CustomerIds
        {
            public const int NEW_ID = 0;
            public const int EXISTING_ID = 1;
            public const int UPDATE_ID = 2;
            public const int ADDED_ID = 4;
            public const int INVALID_ID = 46;
        }

        protected virtual JsonCustomerService SetUpSystemUnderTest()
        {
            var jsonFile = new Mock<IJsonAccess>();
            jsonFile.Setup(x => x.LoadAsync())
                .ReturnsAsync(JObject.Parse(Utils.GetDatabaseSeedJson()));
            var dataSource = new JsonDataSource(jsonFile.Object);
            return new JsonCustomerService(dataSource);
        }
    }
    
}

