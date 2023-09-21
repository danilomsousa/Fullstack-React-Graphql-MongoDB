using GraphQL.Core.Entities;

namespace GraphQL.Infra.Connector
{
    /// <summary>
    /// Interfae <c>IVenuesApiService</c> provides the connection with external API.
    /// </summary>
    public interface IVenuesApiService
    {
        /// <summary>
        /// Method <c>GetVenuesAsync</c> provides all the Venues from external API.
        /// </summary>
        Task<VenuesResponse> GetVenuesAsync();

        /// <summary>
        /// Method <c>GetVenueByIdAsync</c> provides the Venue Detailed from external API based on Id.
        /// </summary>
        Task<VenueDetailedApiResponse> GetVenueByIdAsync(string id);
    }
}