using GraphQL.Core.Entities;

namespace GraphQL.Infra.Connector
{   

    public interface IVenuesApiService
    {
        Task<VenuesResponse> GetVenuesAsync();

        Task<VenueDetailedApiResponse> GetVenueByIdAsync(string id);
    }
}