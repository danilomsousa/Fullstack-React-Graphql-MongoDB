using System;
using System.Collections.Generic;

public class VenueDetailedApiResponse
{
    public VenueDetailedResponse? venue { get; set; }
}

public class VenueDetailedResponse
{
    public required int id { get; set; }
    public double lat { get; set; } = 0;
    public string postcode { get; set; } = String.Empty;
    public string email { get; set; } = String.Empty;
    public long created_on { get; set; } = 0;
    public double lon { get; set; } = 0;
    public string state { get; set; } = String.Empty;
    public string phone { get; set; } = String.Empty;
    public long updated_on { get; set; } = 0;
    public string category { get; set; } = String.Empty;
    public string country { get; set; } = String.Empty;
    public string fax { get; set; } = String.Empty;
    public string logo { get; set; } = String.Empty;
    public string name { get; set; } = String.Empty;
    public string website { get; set; } = String.Empty; 
    public string opening_hours { get; set; } = String.Empty;                           
    public string atm_provider_name { get; set; } = String.Empty;
    public string logo_url { get; set; } = String.Empty;
    public string name_ascii { get; set; } = String.Empty;
    public string facebook { get; set; } = String.Empty;
    public string description { get; set; } = String.Empty;
    public string atm_operator_name { get; set; } = String.Empty;
    public string coupon { get; set; } = String.Empty;    
    public string street { get; set; } = String.Empty;
    public string twitter { get; set; } = String.Empty;
    public string location { get; set; } = String.Empty;
    public string parking { get; set; } = String.Empty;
    public string coupon_expiration { get; set; } = String.Empty;
    public string src_id { get; set; } = String.Empty;
    public string houseno { get; set; } = String.Empty;
    public string instagram { get; set; } = String.Empty;
    public string promoted_until { get; set; } = String.Empty;
    public string daily_limits { get; set; } = String.Empty;
    public string coupon_description { get; set; } = String.Empty;
    public string city { get; set; } = String.Empty;
    public string premium_until { get; set; } = String.Empty;
    public List<string> coins { get; set; } = null!;
    public User user { get; set; } = null!;
    public string geolocation_degrees { get; set; } = String.Empty; 
}

public class User
{
    public string? userhash { get; set; }
}
