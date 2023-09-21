namespace GraphQL.Core.Entities
{
    /// <summary>
    /// Class <c>Venue</c> stores Venue basic information.
    /// </summary>
    public class Venue : BaseEntity
    {
        public required string SourceId { get; set; }
        public string? Name { get; set; }
        public Category Category { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long CreateOn { get; set; }
        public string? GeolocationDegrees { get; set; }
    }
}
