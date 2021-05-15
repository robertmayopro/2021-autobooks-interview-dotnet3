
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.Services.Repository
{
    /// <summary>
    /// Provides a loading and persistence mechanism to and from a JSON source.
    /// </summary>
    public interface IJsonAccess
    {
        /// <summary>
        /// Load JSON from source and pars into a <see cref="JObject"/>.
        /// </summary>
        /// <returns></returns>
        public Task<JObject> LoadAsync();
        
        /// <summary>
        /// Persists <see cref="JObject" /> back to source.
        /// </summary>
        /// <returns></returns>
        public Task SaveAsync();
    }
}