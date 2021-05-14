using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.Services.Repository
{
    public interface IJsonFile
    {
        public JObject Load();
        public Task Save();
    }
}