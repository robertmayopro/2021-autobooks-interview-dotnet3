using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JsonPathway;
using Newtonsoft.Json;

namespace GroceryStoreLibrary.Services.Repository
{
    public class JsonFileDataSource :IJsonDataSource
    {
        private readonly string _fileName;
        private JsonDocument _data;
        
        public JsonFileDataSource(string fileName)
        {
            _fileName = fileName;
            Load();
        }

        public async Task<T> Create<T>(string key, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T[]> Read<T>(string query)
        {
            var result = JsonPath.ExecutePath(query, _data);
            return Task.FromResult( result.Select(x => JsonConvert.DeserializeObject<T>(x.GetRawText())).ToArray());
        }

        public async Task<T> ReadOne<T>(string query)
        {
            var result = await Read<T>(query);
            return result.FirstOrDefault();
        }

        public async Task<T> Update<T>(string key, T entity)
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            using StreamReader file = File.OpenText(_fileName);
            _data = JsonDocument.Parse(file.ReadToEnd());
        }

        public async Task Persist()
        {
            throw new NotImplementedException();
        }
    }
}
