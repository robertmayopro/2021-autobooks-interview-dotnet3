using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JsonPathway;
using Newtonsoft.Json;

namespace GroceryStoreLibrary.Services.Repository
{
    public class JsonDataSource : IJsonDataSource
    {
        protected JsonDocument Data;

        public async Task<T> Create<T>(string key, T entity)
        {


        }

        public Task<T[]> Read<T>(string key, string query)
        {
            var result = JsonPath.ExecutePath($"$.{key}{query}", Data);
            return Task.FromResult(result.SelectMany(Deserialize<T>).ToArray());
        }

        public async Task<T> ReadOne<T>(string key, string query)
        {
            var result = await Read<T>(key, query);
            return result.FirstOrDefault();
        }

        public async Task<T> Update<T>(string key, T entity)
        {
            throw new NotImplementedException();
        }

        private T[] Deserialize<T>(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Array)
                return DeserializeObject<T[]>(element);
            return new[] { DeserializeObject<T>(element) };
        }
        private T DeserializeObject<T>(JsonElement element)
        {
            return JsonConvert.DeserializeObject<T>(element.GetRawText());
        }

    }
}