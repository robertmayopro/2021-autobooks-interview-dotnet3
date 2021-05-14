using System.Threading.Tasks;
using GroceryStoreLibrary.Models;

namespace GroceryStoreLibrary.Services.Repository
{
    public interface IJsonDataSource
    {
        public Task<T> Create<T>(string key, T entity)
            where T : IEntity;
        public Task<T> ReadOne<T>(string key, string query)
            where T : IEntity;
        public Task<T[]> Read<T>(string key, string query)
            where T : IEntity;
        public Task<T> Update<T>(string key, T entity)
            where T : IEntity;
    }
}