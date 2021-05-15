using System.Threading.Tasks;
using GroceryStoreLibrary.Models;

namespace GroceryStoreLibrary.Services.Repository
{
    /// <summary>
    /// Represents a catalog of entities.
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Creates a new entity in the catalog.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="tableName">The table name which holds the entities</param>
        /// <param name="entity">The entity to create.</param>
        /// <returns></returns>
        public Task<T> Create<T>(string tableName, T entity)
            where T : class, IEntity;

        /// <summary>
        /// Reads a single entity from the catalog.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="tableName">The table name which holds the entities</param>
        /// <param name="query">The query used to retrieve the entity.</param>
        /// <returns></returns>
        public Task<T> ReadOne<T>(string tableName, string query)
            where T : class, IEntity;

        /// <summary>
        /// Reads an array of entities from the catalog.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="tableName">The table name which holds the entities</param>
        /// <param name="query">The query used to retrieve the entities.</param>
        /// <returns>Returns information for the newly added entity.</returns>
        public Task<T[]> Read<T>(string tableName, string query)
            where T : class, IEntity;

        /// <summary>
        /// Updates an existing entity in the catalog.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="tableName">The table name which holds the entities</param>
        /// <param name="entity">The entity information to.</param>
        /// <returns>Returns true if a successful update occurred. Otherwise, false.</returns>
        /// <remarks>Uses the <see cref="P:IEntity.ID"/> to find the appropriate entity to update.</remarks>
        public Task<T> Update<T>(string tableName, T entity)
            where T : class, IEntity;
    }
}