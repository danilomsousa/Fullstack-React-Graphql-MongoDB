namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class VenueType : ObjectType<Venue>
    {
        protected override void Configure(IObjectTypeDescriptor<Venue> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.SourceId);
            descriptor.Field(_ => _.Category);
            descriptor.Field(_ => _.Name);
            descriptor.Field(_ => _.GeolocationDegrees);
            descriptor.Field(_ => _.Latitude);
            descriptor.Field(_ => _.Longitude);
            descriptor.Field(_ => _.CreateOn);
            descriptor.Field<CategoryResolver>(_ => _.GetCategoryAsync(default, default));
        }
    }
}