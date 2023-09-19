
using GraphQL.API.Queries;
using GraphQL.API.Resolvers;
using GraphQL.API.Types;
using GraphQL.Core.Repositories;
using GraphQL.Infra.Data;
using GraphQL.Infra.Repositories;
using GraphQL.Infra.Connector;

namespace GraphQL.API
{
    public class Startup
    {

    private readonly ApiConfiguration apiConfiguration;
        // Constructor
    public Startup(IConfiguration configuration)
    {        
        this.apiConfiguration = configuration.Get<ApiConfiguration>();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configurations
        services.AddSingleton(this.apiConfiguration.MongoDbConfiguration);
        services.AddSingleton(this.apiConfiguration.ApiServiceConfiguration);

        // Repositories
        services.AddSingleton<ICatalogContext, CatalogContext>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IVenueRepository, VenueRepository>();
        services.AddSingleton<IVenuesApiService, VenuesApiService>();

        //Add Cors    
        services.AddCors(options =>
        {
        options.AddDefaultPolicy(
            builder =>
            {
                builder.WithOrigins("*")
                    .AllowAnyHeader();
            });
        });

        // GraphQL
        services
            .AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
                        .AddTypeExtension<VenueQuery>()  
                        .AddTypeExtension<CategoryQuery>()                  
            .AddType<VenueType>()
            .AddType<CategoryResolver>();

        services.AddHostedService<Worker>();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseCors();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL("/api/graphql");
        });
        }
    }
}
