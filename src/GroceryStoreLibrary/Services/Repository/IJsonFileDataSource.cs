using System.Threading.Tasks;

namespace GroceryStoreLibrary.Services.Repository
{
    public interface IJsonFileDataSource
    {
        public void Load();
        public Task Persist();
    }
}