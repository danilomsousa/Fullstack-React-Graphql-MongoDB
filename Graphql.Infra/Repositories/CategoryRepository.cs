namespace GraphQL.Infra.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infra.Data;

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}