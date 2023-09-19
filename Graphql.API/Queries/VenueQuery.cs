namespace GraphQL.API.Queries
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Query")]
    public class VenueQuery
    {
        public Task<IEnumerable<Venue>> GetVenuesAsync([Service] IVenueRepository venueRepository) =>
            venueRepository.GetAllAsync();

        public Task<Venue> GetVenueById(string id, [Service] IVenueRepository venueRepository) =>
            venueRepository.GetByIdAsync(id);

        public Task<IEnumerable<Venue>> GetVenuesByCategoryAsync(string categoryId, [Service] IVenueRepository venueRepository) =>
            venueRepository.GetVenuesByCategoryAsync(categoryId);

        public Task<VenueDetailed> GetVenueDetailedByIdAsync(string id, [Service] IVenueRepository venueRepository) =>
            venueRepository.GetVenueDetailedByIdAsync(id);
    }
}