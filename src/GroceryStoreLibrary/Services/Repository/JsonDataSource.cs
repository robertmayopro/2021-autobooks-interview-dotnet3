using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.Services.Repository
{
    /// <summary>
    /// JSON-specific data source.
    /// </summary>
    public class JsonDataSource : IJsonDataSource
    {
        private readonly IJsonAccess _jsonAccess;
        private readonly JObject _data;

        /// <summary>
        /// Creates an instance of a <see cref="JsonDataSource"/>.
        /// </summary>
        /// <param name="jsonAccess">Loading and persistence mechanism to and from a JSON source</param>
        public JsonDataSource(
            IJsonAccess jsonAccess
            )
        {
            _jsonAccess = jsonAccess;

            var loadTask = _jsonAccess.LoadAsync();
            Task.WaitAll(loadTask);
            _data = loadTask.Result;
        }

        /// <inheritdoc cref="IDataSource"/>
        public async Task<T> Create<T>(string tableName, T entity)
            where T : class, IEntity
        {
            if (entity == null) throw new ArgumentNullException($"Cannot add null to '{tableName}'.", nameof(entity));

            JArray table = (JArray)_data.SelectTokens($"$.{tableName}").SingleOrDefault();
            if (table == null) throw new ArgumentException($"Table not found, '{tableName}'.", nameof(tableName));

            // TODO: Thread-safety, concurrency, pessimistic locking
            int nextId = (Deserialize<T>(table).Select(x => x.Id).Max()) + 1;
            entity.Id = nextId;
            table.Add(JObject.Parse(JsonConvert.SerializeObject(entity)));
            await _jsonAccess.SaveAsync();

            return entity;
        }

        /// <inheritdoc cref="IDataSource"/>
        public Task<T[]> Read<T>(string tableName, string query)
            where T : class, IEntity
        {
            JArray table = (JArray)_data.SelectTokens($"$.{tableName}").SingleOrDefault();
            if (table == null) throw new ArgumentException($"Table not found, '{tableName}'.", nameof(tableName));

            var result = _data.SelectTokens($"$.{tableName}{query}").ToArray();
            return Task.FromResult(result.SelectMany(Deserialize<T>).ToArray());
        }

        /// <inheritdoc cref="IDataSource"/>
        public async Task<T> ReadOne<T>(string tableName, string query)
            where T : class, IEntity
        {
            var result = await Read<T>(tableName, query);
            return result.FirstOrDefault();
        }

        /// <inheritdoc cref="IDataSource"/>
        public async Task<T> Update<T>(string tableName, T entity)
            where T : class, IEntity
        {
            JArray table = (JArray)_data.SelectTokens($"$.{tableName}").SingleOrDefault();
            if (table == null) throw new ArgumentException($"Table not found, '{tableName}'.", nameof(tableName));

            var existing = _data.SelectToken($"$.{tableName}[?(@.id == {entity.Id})]");
            if (existing == null) throw new KeyNotFoundException($"No {tableName} found with id {entity.Id}'.");

            existing.Replace(JObject.Parse(JsonConvert.SerializeObject(entity)));
            await _jsonAccess.SaveAsync();

            return entity;
        }

        private T[] Deserialize<T>(JToken element)
            where T : class, IEntity
        {
            if (element.Type == JTokenType.Array)
                return element.ToObject<T[]>();
            return new[] { element.ToObject<T>() };
        }

    }
}