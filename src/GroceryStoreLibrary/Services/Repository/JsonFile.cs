using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroceryStoreLibrary.Services.Repository
{
    /// <summary>
    /// Loads JSON data from a file and persists it back to that file.
    /// </summary>
    public class JsonFile : IJsonAccess
    {
        private readonly string _fileName;
        private JObject _json;

        /// <summary>
        /// Creates a new instance of a JsonFile, loading from and saving to the specified path.
        /// </summary>
        /// <param name="fileName">Path on isk where the JSON file is located.</param>
        public JsonFile(string fileName)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// Loads JSON Data from file.
        /// </summary>
        /// <returns></returns>
        public async Task<JObject> LoadAsync()
        {
            string json = await File.ReadAllTextAsync(_fileName);
            return _json = JObject.Parse(json);
        }

        /// <summary>
        /// Saves JSON data to file
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            // TODO: Thread Safety, concurrency
            // This reminds me of a story.

            Directory.CreateDirectory(Path.GetDirectoryName(_fileName));
            if (File.Exists(_fileName)) File.Delete(_fileName);
            await using var fileStream = File.OpenWrite(_fileName);
            await using var textWriter = new StreamWriter(fileStream);
            using var writer = new JsonTextWriter(textWriter);
            await _json.WriteToAsync(writer);
        }
    }
}
