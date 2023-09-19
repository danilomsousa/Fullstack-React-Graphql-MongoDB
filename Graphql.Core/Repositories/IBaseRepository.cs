using GraphQL.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

﻿namespace GraphQL.Core.Repositories
{   
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> InsertAsync(T entity);
        Task<bool> RemoveAsync(string id);
    }
}