namespace GraphQL.Infra.Data
{
    using MongoDB.Driver;

    public interface ICatalogContext
    {
        IMongoCollection<T> GetCollection<T>(string name);

        void ReloadDatabase();
    }
}