using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.Services.Repository
{
    public class JsonFile : IJsonFile
    {
        private readonly string _fileName;
        private JObject _json;

        public JsonFile(string fileName)
        {
            _fileName = fileName;
        }

        public JObject Load()
        {
            string json = File.ReadAllText(_fileName);
            return _json = JObject.Parse(json);
        }

        public async Task Save()
        {
            // TODO: Thread Safety, concurrency
            // This reminds me of a story.
            if (File.Exists(_fileName)) File.Delete(_fileName);
            await using var fileStream = File.OpenWrite(_fileName);
            await using var textWriter = new StreamWriter(fileStream);
            using var writer = new JsonTextWriter(textWriter);
            await _json.WriteToAsync(writer, null);
        }
    }
}
