using System.IO;
using System.Threading.Tasks;
using GroceryStoreLibrary.Services.Repository;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests.Services.Repository
{
    class JsonFileTests
    {

        [Test]
        public async Task ShouldLoadJsonFileFromDisk()
        {
            // Arrange
            string testDirectory = GetTestDirectory();
            Directory.CreateDirectory(testDirectory);
            string jsonFileName = "ShouldLoadJsonFileFromDisk.database.json";
            string jsonFilePath = Path.Combine(testDirectory, jsonFileName);
            File.WriteAllText(jsonFilePath, Utils.GetDatabaseSeedJson());
            var sut = new JsonFile(jsonFilePath);

            // Act
            var loaded = await sut.LoadAsync();

            // Assert
            Assert.That(loaded, Is.Not.Null, "Unable to parse JSON contents from disk.");
            
            // Verify integrity

            var customers = loaded.SelectToken("customers");
            Assert.That(customers, Is.Not.Null, "Unable to locate the customers node.");
            Assert.That(customers, Is.AssignableTo(typeof(JArray)), "Customers node does not appear to be an array.");
            
            var customersArray = (JArray)customers;
            Assert.That(customersArray.Count, Is.EqualTo(3), "Customers count does not match.");
            Assert.That(customersArray[0], Is.Not.Null);
            Assert.That(customersArray[0].Type, Is.EqualTo(JTokenType.Object));
            Assert.That(customersArray[0]["id"], Is.Not.Null);
            Assert.That(customersArray[0]["id"].Type, Is.EqualTo(JTokenType.Integer));
            Assert.That(customersArray[0]["id"].Value<int>(), Is.EqualTo(1));
            Assert.That(customersArray[0]["name"], Is.Not.Null);
            Assert.That(customersArray[0]["name"].Type, Is.EqualTo(JTokenType.String));
            Assert.That(customersArray[0]["name"].Value<string>(), Is.EqualTo("Bob"));
            Assert.That(customersArray[1]["id"], Is.Not.Null);
            Assert.That(customersArray[1]["id"].Type, Is.EqualTo(JTokenType.Integer));
            Assert.That(customersArray[1]["id"].Value<int>(), Is.EqualTo(2));
            Assert.That(customersArray[1]["name"], Is.Not.Null);
            Assert.That(customersArray[1]["name"].Type, Is.EqualTo(JTokenType.String));
            Assert.That(customersArray[1]["name"].Value<string>(), Is.EqualTo("Mary"));
            Assert.That(customersArray[2]["id"], Is.Not.Null);
            Assert.That(customersArray[2]["id"].Type, Is.EqualTo(JTokenType.Integer));
            Assert.That(customersArray[2]["id"].Value<int>(), Is.EqualTo(3));
            Assert.That(customersArray[2]["name"], Is.Not.Null);
            Assert.That(customersArray[2]["name"].Type, Is.EqualTo(JTokenType.String));
            Assert.That(customersArray[2]["name"].Value<string>(), Is.EqualTo("Joe"));
        }

        [Test]
        public async Task ShouldSaveModifiedJsonToDisk()
        {
            // Arrange
            string testDirectory = GetTestDirectory();
            Directory.CreateDirectory(testDirectory);
            string jsonFileName = "ShouldSaveModifiedJsonToDisk.database.json";
            string jsonFilePath = Path.Combine(testDirectory, jsonFileName);
            await File.WriteAllTextAsync(jsonFilePath, Utils.GetDatabaseSeedJson());
            var sut = new JsonFile(jsonFilePath);
            var root = await sut.LoadAsync();

            // Act
            ((JArray)root.SelectToken("customers")).Add(JObject.Parse("{id:4, name:\"Ellen\"}"));
            await sut.SaveAsync();

            // Assert
            string json = await File.ReadAllTextAsync(jsonFilePath);
            var loaded = JObject.Parse(json);

            // Verify integrity

            var customers = loaded.SelectToken("customers");
            Assert.That(customers, Is.Not.Null, "Unable to locate the customers node.");
            Assert.That(customers, Is.AssignableTo(typeof(JArray)), "Customers node does not appear to be an array.");

            var customersArray = (JArray)customers;
            Assert.That(customersArray.Count, Is.EqualTo(4), "Customers count does not match.");
            Assert.That(customersArray[0], Is.Not.Null);
            Assert.That(customersArray[0].Type, Is.EqualTo(JTokenType.Object));
            Assert.That(customersArray[0]["id"], Is.Not.Null);
            Assert.That(customersArray[0]["id"].Type, Is.EqualTo(JTokenType.Integer));
            Assert.That(customersArray[0]["id"].Value<int>(), Is.EqualTo(1));
            Assert.That(customersArray[0]["name"], Is.Not.Null);
            Assert.That(customersArray[0]["name"].Type, Is.EqualTo(JTokenType.String));
            Assert.That(customersArray[0]["name"].Value<string>(), Is.EqualTo("Bob"));
            Assert.That(customersArray[1]["id"], Is.Not.Null);
            Assert.That(customersArray[1]["id"].Type, Is.EqualTo(JTokenType.Integer));
            Assert.That(customersArray[1]["id"].Value<int>(), Is.EqualTo(2));
            Assert.That(customersArray[1]["name"], Is.Not.Null);
            Assert.That(customersArray[1]["name"].Type, Is.EqualTo(JTokenType.String));
            Assert.That(customersArray[1]["name"].Value<string>(), Is.EqualTo("Mary"));
            Assert.That(customersArray[2]["id"], Is.Not.Null);
            Assert.That(customersArray[2]["id"].Type, Is.EqualTo(JTokenType.Integer));
            Assert.That(customersArray[2]["id"].Value<int>(), Is.EqualTo(3));
            Assert.That(customersArray[2]["name"], Is.Not.Null);
            Assert.That(customersArray[2]["name"].Type, Is.EqualTo(JTokenType.String));
            Assert.That(customersArray[2]["name"].Value<string>(), Is.EqualTo("Joe"));
            Assert.That(customersArray[3]["id"], Is.Not.Null);
            Assert.That(customersArray[3]["id"].Type, Is.EqualTo(JTokenType.Integer));
            Assert.That(customersArray[3]["id"].Value<int>(), Is.EqualTo(4));
            Assert.That(customersArray[3]["name"], Is.Not.Null);
            Assert.That(customersArray[3]["name"].Type, Is.EqualTo(JTokenType.String));
            Assert.That(customersArray[3]["name"].Value<string>(), Is.EqualTo("Ellen"));
        }

        private string GetTestDirectory()
        {
            return Path.Combine(TestSession.WorkingDirectory, GetType().Name);
        }
    }
}
