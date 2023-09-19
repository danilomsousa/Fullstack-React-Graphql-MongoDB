namespace GraphQL.Infra.Data
{
    using GraphQL.Core.Entities;
    using GraphQL.Infra.Connector;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;

    public class CatalogContextSeed
    {
        public static VenuesResponse venues;
        public static Dictionary<string, ObjectId> categoriesId;
        public static int batchSize = 500;
        public async static void SeedData(IMongoDatabase database, IVenuesApiService venuesApiService)
        {         

            System.Console.WriteLine("Starting seedData.");
            var watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();           
            venues = await venuesApiService.GetVenuesAsync();
            System.Console.WriteLine("Received {0} venues.", venues.venues.Count);

            if(categoriesId == null) categoriesId = new Dictionary<string, ObjectId>();

            InsertCategories(database.GetCollection<Category>(nameof(Category)));
            InsertVenues(database.GetCollection<Venue>(nameof(Venue)));

            watch.Stop();
            Console.WriteLine("Finished seedData, elapsed Time is {0} ms", watch.ElapsedMilliseconds);
        }

        private static void InsertCategories(IMongoCollection<Category> categoryCollection)
        {
            categoryCollection.DeleteMany(_ => true);
            categoriesInsertList(categoryCollection);           
        }

        [Obsolete]
        private static void categoriesInsertList(IMongoCollection<Category> categoryCollection)
        {          
            var categoriesList = new List<Category>();                        
            foreach(var venue in venues.venues){
                if(!categoriesId.ContainsKey(venue.category.ToUpper())){
                    categoriesId.Add(venue.category.ToUpper(), ObjectId.GenerateNewId());                    
                }         
            }

            foreach(var category in categoriesId){
                categoriesList.Add(new Category { Id = category.Value.ToString(), Description = category.Key});
            }

            if(categoriesList.Count > 0) categoryCollection.InsertManyAsync(categoriesList);
        }

        private static void InsertVenues(IMongoCollection<Venue> venueCollection)
        {
            venueCollection.DeleteMany(_ => true);
            venuesInsertList(venueCollection);            
        }

        private static void venuesInsertList(IMongoCollection<Venue> venueCollection)
        {            
            var venuesList = new List<Venue>(); 
            var countLoop = 0;           
            foreach(var venue in venues.venues){
                venuesList.Add(new Venue{SourceId = venue.id.ToString(), Name = venue.name, Category = new Category { Id = categoriesId[venue.category.ToUpper()].ToString(), Description = venue.category}, 
                                GeolocationDegrees = venue.geolocation_degrees, Latitude = venue.lat, Longitude = venue.lon, CreateOn = venue.created_on});
                if(countLoop == batchSize){
                    venueCollection.InsertManyAsync(venuesList);
                    venuesList.Clear();
                    countLoop = 0;
                    continue;
                }
                countLoop++;
            }            

            if(venuesList.Count > 0) venueCollection.InsertManyAsync(venuesList);

        }
    }
}