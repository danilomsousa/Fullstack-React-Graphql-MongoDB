
public class VenuesResponse
{
    public List<Venue>? venues { get; set; }
}

public class Venue
{
    public required int id { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string? category { get; set; }
    public string? name { get; set; }
    public long created_on { get; set; }
    public string? geolocation_degrees { get; set; }
}
