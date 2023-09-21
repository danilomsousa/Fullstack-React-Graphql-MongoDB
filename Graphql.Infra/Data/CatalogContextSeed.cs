namespace GraphQL.Infra.Data
{
    using GraphQL.Core.Entities;
    using GraphQL.Infra.Connector;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class <c>CatalogContextSeed</c> provides the load from external API to MongoDB.
    /// </summary>
    public class CatalogContextSeed
    {
        /// <summary>
        /// Dictionary <c>categoriesId</c> provides the list of Categories and the IDs.
        /// </summary>
        public static Dictionary<string, ObjectId> categoriesId = new Dictionary<string, ObjectId>();

        /// <summary>
        /// int <c>batchSize</c> provides the size of batch to be inserted on MongoDB.
        /// </summary>
        public static int batchSize = 500;

        public async static void SeedData(IMongoDatabase database, IVenuesApiService venuesApiService)
        {         

            System.Console.WriteLine("Starting seedData.");
            var watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            VenuesResponse venues = await venuesApiService.GetVenuesAsync();

            if(venues.venues == null || venues.venues.Count == 0) 
                throw new NullReferenceException("External Service GetVenuesAsync returns null value");

            System.Console.WriteLine("Received {0} venues.", venues.venues.Count);                        

            InsertCategories(database.GetCollection<Category>(nameof(Category)), venues);
            InsertVenues(database.GetCollection<Venue>(nameof(Venue)), venues);

            watch.Stop();
            Console.WriteLine("Finished seedData, elapsed Time is {0} ms", watch.ElapsedMilliseconds);
        }

        private static void InsertCategories(IMongoCollection<Category> categoryCollection, VenuesResponse venues)
        {
            categoryCollection.DeleteMany(_ => true);
            categoriesInsertList(categoryCollection, venues);           
        }
                
        private static void categoriesInsertList(IMongoCollection<Category> categoryCollection, VenuesResponse venues)
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

        private static void InsertVenues(IMongoCollection<Venue> venueCollection, VenuesResponse venues)
        {
            venueCollection.DeleteMany(_ => true);
            venuesInsertList(venueCollection, venues);            
        }

        private static void venuesInsertList(IMongoCollection<Venue> venueCollection, VenuesResponse venues)
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