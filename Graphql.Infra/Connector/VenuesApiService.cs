using System;
using System.Net.Http;
using System.Threading.Tasks;
using GraphQL.Core.Entities;
using GraphQL.Infra.Configurations;
using Newtonsoft.Json; // Make sure to install the Newtonsoft.Json NuGet package

namespace GraphQL.Infra.Connector
{  
public class VenuesApiService : IVenuesApiService
{
    private readonly HttpClient _httpClient;    

    private readonly string venuesPath = "venues";

    public VenuesApiService(ApiServiceConfiguration apiServiceConfiguration)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(apiServiceConfiguration.BaseUrl);
    }

    public async Task<VenuesResponse> GetVenuesAsync()
    {
        try
        {            
            HttpResponseMessage response = await _httpClient.GetAsync(String.Concat(venuesPath, "/"));

            if (response.IsSuccessStatusCode)
            {                
                string content = await response.Content.ReadAsStringAsync();
                VenuesResponse result = JsonConvert.DeserializeObject<VenuesResponse>(content);
                return result;
            }
            else
            {                
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {            
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<VenueDetailedApiResponse> GetVenueByIdAsync(string id)
    {
        try
        {            
            HttpResponseMessage response = await _httpClient.GetAsync(String.Concat(venuesPath, "/", id));

            if (response.IsSuccessStatusCode)
            {                
                string content = await response.Content.ReadAsStringAsync();
                VenueDetailedApiResponse result = JsonConvert.DeserializeObject<VenueDetailedApiResponse>(content);
                return result;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {            
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}
}
