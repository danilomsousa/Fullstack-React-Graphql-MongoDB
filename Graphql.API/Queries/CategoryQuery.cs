namespace GraphQL.API.Queries
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Class <c>CategoryQuery</c> provides the Category queries available on GraphQL.
    /// </summary>
    [ExtendObjectType(Name = "Query")]
    public class CategoryQuery
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync([Service] ICategoryRepository categoryRepository) =>
            categoryRepository.GetAllAsync();
        
    }
}