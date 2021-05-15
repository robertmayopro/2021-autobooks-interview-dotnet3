using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace GroceryStoreLibrary.Models
{
    [ExcludeFromCodeCoverage]
    public class Customer : IEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
