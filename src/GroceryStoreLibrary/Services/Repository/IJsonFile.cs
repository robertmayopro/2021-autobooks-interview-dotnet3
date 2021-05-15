using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.Services.Repository
{
    public interface IJsonFile
    {
        public Task<JObject> LoadAsync();
        public Task SaveAsync();
    }
}