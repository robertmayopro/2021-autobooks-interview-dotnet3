using System.Text;
using GroceryStoreLibrary.Models;

namespace GroceryStoreLibrary.UnitTests.Services.Repository.JsonDataSourceTests
{
    class GroceryStore : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
