using System;
using System.Collections.Generic;

public class VenueDetailedApiResponse
{
    public VenueDetailedResponse venue { get; set; }
}

public class VenueDetailedResponse
{
    public double lat { get; set; }
    public string postcode { get; set; }
    public string email { get; set; }
    public long created_on { get; set; }
    public double lon { get; set; }
    public string state { get; set; }
    public string phone { get; set; }
    public long updated_on { get; set; }
    public string category { get; set; }
    public string country { get; set; }
    public string fax { get; set; }
    public string logo { get; set; }
    public string name { get; set; }
    public string website { get; set; }
    public string opening_hours { get; set; }
    public string atm_provider_name { get; set; }
    public string logo_url { get; set; }
    public string name_ascii { get; set; }
    public string facebook { get; set; }
    public string description { get; set; }
    public string atm_operator_name { get; set; }
    public string coupon { get; set; }
    public int id { get; set; }
    public string street { get; set; }
    public string twitter { get; set; }
    public string location { get; set; }
    public string parking { get; set; }
    public string coupon_expiration { get; set; }
    public string src_id { get; set; }
    public string houseno { get; set; }
    public string instagram { get; set; }
    public string promoted_until { get; set; }
    public string daily_limits { get; set; }
    public string coupon_description { get; set; }
    public string city { get; set; }
    public string premium_until { get; set; }
    public List<string> coins { get; set; }
    public User user { get; set; }
    public string geolocation_degrees { get; set; }
}

public class User
{
    public string userhash { get; set; }
}
