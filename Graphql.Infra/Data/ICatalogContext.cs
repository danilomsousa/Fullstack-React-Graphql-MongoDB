namespace GraphQL.Infra.Data
{
    using MongoDB.Driver;

    /// <summary>
    /// Interfae <c>ICatalogContext</c> provides the connection with MongoDB.
    /// </summary>
    public interface ICatalogContext
    {
        /// <summary>
        /// Method <c>GetCollection</c> provides the collection from MongoDB based on the name.
        /// </summary>
        IMongoCollection<T> GetCollection<T>(string name);

        /// <summary>
        /// Method <c>ReloadDatabase</c> perfomsn the reload of the MongoDB.
        /// </summary>
        void ReloadDatabase();
    }
}