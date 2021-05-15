using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using GroceryStoreLibrary.Models;

namespace GroceryStoreLibrary.Services.Repository
{
    [ExcludeFromCodeCoverage]

#pragma warning disable 1591
    public class SqliteDataSource : IDataSource
    {
        //TODO: Alternate implementation


        public Task<T> Create<T>(string tableName, T entity) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public Task<T> ReadOne<T>(string tableName, string query) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public Task<T[]> Read<T>(string tableName, string query) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public Task<T> Update<T>(string tableName, T entity) where T : class, IEntity
        {
            throw new NotImplementedException();
        }
    }
#pragma warning restore 1591
}
