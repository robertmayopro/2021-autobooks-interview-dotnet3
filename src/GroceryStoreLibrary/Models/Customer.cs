using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace GroceryStoreLibrary.Models
{
    /// <summary>
    /// Represents a registered customer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Customer : IEntity
    {
        /// <summary>Customer ID</summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>Customer Name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
