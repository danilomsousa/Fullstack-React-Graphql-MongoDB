

using GraphQL.Infra.Configurations;

public class ApiConfiguration
{
    public MongoDbConfiguration MongoDbConfiguration { get; set; }

    public ApiServiceConfiguration ApiServiceConfiguration { get; set;}
}
