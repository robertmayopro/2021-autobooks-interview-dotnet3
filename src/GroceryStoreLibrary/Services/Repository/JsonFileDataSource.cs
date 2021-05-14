using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GroceryStoreLibrary.Services.Repository
{
    public class JsonFileDataSource : JsonDataSource, IJsonFileDataSource
    {
        private readonly string _fileName;

        public JsonFileDataSource(string fileName)
        {
            _fileName = fileName;
            Load();
        }

        public void Load()
        {
            using StreamReader file = File.OpenText(_fileName);
            Data = JsonDocument.Parse(file.ReadToEnd());
        }

        public async Task Persist()
        {
            // TODO: 
        }
    }
}
