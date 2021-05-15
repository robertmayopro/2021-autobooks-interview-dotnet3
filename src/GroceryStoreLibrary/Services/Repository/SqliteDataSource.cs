using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using GroceryStoreLibrary.Models;

namespace GroceryStoreLibrary.Services.Repository
{
    [ExcludeFromCodeCoverage]

    public class SqliteDataSource : IDataSource
    {
        //TODO: Alternate implementation

        
        public async Task<T> Create<T>(string tableName, T entity) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<T> ReadOne<T>(string tableName, string query) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<T[]> Read<T>(string tableName, string query) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update<T>(string tableName, T entity) where T : class, IEntity
        {
            throw new NotImplementedException();
        }
    }
}
