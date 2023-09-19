namespace GraphQL.Infra.Data
{
    using GraphQL.Infra.Configurations;
    using GraphQL.Infra.Connector;
    using MongoDB.Driver;

    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoDatabase database;
        private readonly IVenuesApiService venuesApiService;

        public CatalogContext(MongoDbConfiguration mongoDbConfiguration, IVenuesApiService venuesApiService)
        {
            var client = new MongoClient(mongoDbConfiguration.ConnectionString);

            this.database = client.GetDatabase(mongoDbConfiguration.Database);

            this.venuesApiService = venuesApiService;            
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return this.database.GetCollection<T>(name);
        }

        public void ReloadDatabase(){
            CatalogContextSeed.SeedData(this.database, venuesApiService);
        }
    }
}