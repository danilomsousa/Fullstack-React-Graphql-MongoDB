using GraphQL.Core.Entities;

﻿namespace GraphQL.Core.Repositories
{    
    public interface IVenueRepository : IBaseRepository<Venue>
    {
        Task<IEnumerable<Venue>> GetVenuesByCategoryAsync(string id);

        Task<VenueDetailed> GetVenueDetailedByIdAsync(string id);
    }
}