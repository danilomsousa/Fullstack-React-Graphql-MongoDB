namespace GraphQL.Infra.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infra.Connector;
    using GraphQL.Infra.Data;    
    using GraphQL.Infra.Conversor;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class VenueRepository : BaseRepository<Venue>, IVenueRepository
    {
        private readonly IMongoCollection<Venue> collection;   

        private readonly IVenuesApiService venuesApiService;     

        public VenueRepository(ICatalogContext catalogContext, IVenuesApiService venuesApiService) : base(catalogContext)
        {
            if (catalogContext == null)
            {
                throw new ArgumentNullException(nameof(catalogContext));
            }

            this.collection = catalogContext.GetCollection<Venue>(typeof(Venue).Name); 
            this.venuesApiService = venuesApiService;           
        }

        public async Task<IEnumerable<Venue>> GetVenuesByCategoryAsync(string id)
        {
            if(!ObjectId.TryParse(id, out _)) return new List<Venue>();

            var filter = Builders<Venue>.Filter.Eq(_ => _.Category.Id, id);

            return await this.collection.Find(filter).ToListAsync();
        }

        public async Task<VenueDetailed> GetVenueDetailedByIdAsync(string id)
        {
            VenueDetailedApiResponse response = await this.venuesApiService.GetVenueByIdAsync(id);            
            return  ConvertVenueDetailed.convertVenueDetailed(response.venue);
        }
    }
}