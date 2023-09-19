using GraphQL.Core.Entities;

namespace GraphQL.Infra.Conversor
{  
public static class ConvertVenueDetailed {

    public static VenueDetailed convertVenueDetailed (VenueDetailedResponse venueResponse){
        return new VenueDetailed {
            SourceId = venueResponse.id.ToString(),
            Name = venueResponse.name,
            Latitude = venueResponse.lat,
            Longitude = venueResponse.lon, 		                        
            Category = new Category { Id = "", Description = venueResponse.category},
            GeolocationDegrees = String.IsNullOrEmpty(venueResponse.geolocation_degrees) ? "" : venueResponse.geolocation_degrees,
            CreateOn = venueResponse.created_on,
            PostCode = String.IsNullOrEmpty(venueResponse.postcode) ? "" : venueResponse.postcode,		
            Email = String.IsNullOrEmpty(venueResponse.email) ? "" : venueResponse.email,            			
            State = String.IsNullOrEmpty(venueResponse.state) ? "" : venueResponse.state,
            Phone = String.IsNullOrEmpty(venueResponse.phone) ? "" : venueResponse.phone,       
            UpdatedOn = venueResponse.updated_on,		
            Country = String.IsNullOrEmpty(venueResponse.country) ? "" : venueResponse.country, 			
            Fax = String.IsNullOrEmpty(venueResponse.fax) ? "" : venueResponse.fax, 				
            Logo = String.IsNullOrEmpty(venueResponse.logo) ? "" : venueResponse.logo,
            Website = String.IsNullOrEmpty(venueResponse.website) ? "" : venueResponse.website,
            OpeningHours = String.IsNullOrEmpty(venueResponse.opening_hours) ? "" : venueResponse.opening_hours, 		
            AtmProviderName = String.IsNullOrEmpty(venueResponse.atm_provider_name) ? "" : venueResponse.atm_provider_name, 	
            LogoURL = String.IsNullOrEmpty(venueResponse.logo_url) ? "" : venueResponse.logo_url,			
            NameAscii = String.IsNullOrEmpty(venueResponse.name_ascii) ? "" : venueResponse.name_ascii, 		
            Facebook = String.IsNullOrEmpty(venueResponse.facebook ) ? "" : venueResponse.facebook , 			
            Description = String.IsNullOrEmpty(venueResponse.description) ? "" : venueResponse.description, 		
            AtmOperatorName = String.IsNullOrEmpty(venueResponse.atm_operator_name) ? "" : venueResponse.atm_operator_name, 	
            Coupon = String.IsNullOrEmpty(venueResponse.coupon) ? "" : venueResponse.coupon, 			
            Street  = String.IsNullOrEmpty(venueResponse.street) ? "" : venueResponse.street,			
            Twitter = String.IsNullOrEmpty(venueResponse.twitter) ? "" : venueResponse.twitter, 			
            Location = String.IsNullOrEmpty(venueResponse.location) ? "" : venueResponse.location,			
            Parking = String.IsNullOrEmpty(venueResponse.parking) ? false : String.Equals(venueResponse.parking.ToLower(), "false") ? false : true, 		
            CouponExpiration = String.IsNullOrEmpty(venueResponse.coupon_expiration) ? "" : venueResponse.coupon_expiration, 	
            Instagram = String.IsNullOrEmpty(venueResponse.instagram) ? "" : venueResponse.instagram,             				
            City  = String.IsNullOrEmpty(venueResponse.city) ? "" : venueResponse.city
        };
    } 
}
}

