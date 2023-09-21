using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

﻿namespace GraphQL.Core.Entities
{
    /// <summary>
    /// Class <c>BaseEntity</c> stores the ID format for DB.
    /// </summary>
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}