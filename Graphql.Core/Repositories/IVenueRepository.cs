using GraphQL.Core.Entities;

﻿namespace GraphQL.Core.Repositories
{
    /// <summary>
    /// Interfae <c>IVenueRepository</c> contais the specific methods for Venue Entity.
    /// </summary>
    public interface IVenueRepository : IBaseRepository<Venue>
    {
        /// <summary>
        /// Method <c>GetVenuesByCategoryAsync</c> returns all the Venues based on the Category Id.
        /// </summary>
        Task<IEnumerable<Venue>> GetVenuesByCategoryAsync(string id);

        /// <summary>
        /// Method <c>GetVenueDetailedByIdAsync</c> returns the Venue Detailed information based on the Venue Id.
        /// </summary>
        Task<VenueDetailed> GetVenueDetailedByIdAsync(string id);
    }
}