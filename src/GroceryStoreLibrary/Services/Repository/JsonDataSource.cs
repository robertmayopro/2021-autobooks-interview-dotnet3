using System;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.Services.Repository
{
    public class JsonDataSource : IJsonDataSource
    {
        private readonly IJsonFile _jsonFile;
        private readonly JObject _data;

        public JsonDataSource(
            IJsonFile jsonFile
            )
        {
            _jsonFile = jsonFile;
            _data = _jsonFile.Load();
        }

        public async Task<T> Create<T>(string key, T entity)
            where T : IEntity
        {
            JArray table = (JArray)_data.SelectTokens($"$.{key}").Single();

            // TODO: Thread-safety, concurrency, pessimistic locking
            int nextId = (table.SelectMany(Deserialize<T>).Select(x => x.Id).Max()) + 1;
            entity.Id = nextId;
            table.Add(JObject.Parse(JsonConvert.SerializeObject(entity)));
            await _jsonFile.Save();

            return entity;
        }

        public Task<T[]> Read<T>(string key, string query)
            where T : IEntity
        {
            var result = _data.SelectTokens($"$.{key}{query}").ToArray();
            return Task.FromResult(result.SelectMany(Deserialize<T>).ToArray());
        }

        public async Task<T> ReadOne<T>(string key, string query)
            where T : IEntity
        {
            var result = await Read<T>(key, query);
            return result.FirstOrDefault();
        }

        public async Task<T> Update<T>(string key, T entity)
            where T : IEntity
        {
            var existing = _data.SelectToken($"$.{key}[?(@.id == {entity.Id})]");
            if (existing != null)
            {
                existing.Replace(JObject.Parse(JsonConvert.SerializeObject(entity)));
            }
            else
            {
                JArray table = (JArray)_data.SelectTokens($"$.{key}").Single();
                table.Add(JObject.Parse(JsonConvert.SerializeObject(entity)));
            }

            await _jsonFile.Save();

            return entity;
        }

        private T[] Deserialize<T>(JToken element)
        {
            if (element.Type == JTokenType.Array)
                return element.ToObject<T[]>();
            return new[] { element.ToObject<T>() };
        }

    }
}