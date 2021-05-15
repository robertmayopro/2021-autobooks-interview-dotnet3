﻿using System.Threading.Tasks;
using GroceryStoreLibrary.Models;

namespace GroceryStoreLibrary.Services.Repository
{
    public interface IJsonDataSource
    {
        public Task<T> Create<T>(string tableName, T entity)
            where T : class, IEntity;
        public Task<T> ReadOne<T>(string tableName, string query)
            where T : class, IEntity;
        public Task<T[]> Read<T>(string tableName, string query)
            where T : class, IEntity;
        public Task<T> Update<T>(string tableName, T entity)
            where T : class, IEntity;
    }
}