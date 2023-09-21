using GraphQL.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

﻿namespace GraphQL.Core.Repositories
{
    /// <summary>
    /// Interfae <c>IBaseRepository</c> provides the basics methods for API.
    /// </summary>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Method <c>GetAllAsync</c> returns all the data from the collection.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Method <c>GetByIdAsync</c> returns all the data filtered by Id from the collection.
        /// </summary>
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// Method <c>InsertAsync</c> inserts a new entity on the collection.
        /// </summary>
        Task<T> InsertAsync(T entity);

        /// <summary>
        /// Method <c>RemoveAsync</c> removes a entity from the collection based on the Id.
        /// </summary>
        Task<bool> RemoveAsync(string id);
    }
}