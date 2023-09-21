namespace GraphQL.Core.Entities
{
    /// <summary>
    /// Class <c>VenueDetailed</c> stores Venue detailed information.
    /// </summary>
    public class VenueDetailed : Venue
    {
        public string PostCode { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public long UpdatedOn { get; set; } = 0;
        public string Country { get; set; } = String.Empty;
        public string Fax { get; set; } = String.Empty;
        public string Logo { get; set; } = String.Empty;
        public string Website { get; set; } = String.Empty;
        public string OpeningHours { get; set; } = String.Empty;
        public string AtmProviderName { get; set; } = String.Empty;
        public string LogoURL { get; set; } = String.Empty;
        public string NameAscii { get; set; } = String.Empty; 
        public string Facebook { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string AtmOperatorName { get; set; } = String.Empty;
        public string Coupon { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
        public string Twitter { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public bool Parking { get; set; }
        public string CouponExpiration { get; set; } = String.Empty;
        public string Instagram { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;

    }
}

   