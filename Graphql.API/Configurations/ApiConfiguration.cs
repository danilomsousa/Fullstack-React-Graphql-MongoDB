using GraphQL.Infra.Configurations;

/// <summary>
/// Class <c>ApiConfiguration</c> provides the configuration from AppSettings file.
/// </summary>
public class ApiConfiguration
{
    public required MongoDbConfiguration MongoDbConfiguration { get; set; }

    public required ApiServiceConfiguration ApiServiceConfiguration { get; set;}
}
