namespace GraphQL.Core.Entities
{
    public class Venue : BaseEntity
    {
        public string SourceId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long CreateOn { get; set; }
        public string GeolocationDegrees { get; set; }
    }
}
