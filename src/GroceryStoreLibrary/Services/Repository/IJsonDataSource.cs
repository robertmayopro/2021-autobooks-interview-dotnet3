using System.Threading.Tasks;

namespace GroceryStoreLibrary.Services.Repository
{
    public interface IJsonDataSource
    {
        public Task<T> Create<T>(string key, T entity);
        public Task<T> ReadOne<T>(string key, string query);
        public Task<T[]> Read<T>(string key, string query);
        public Task<T> Update<T>(string key, T entity);


    }
}