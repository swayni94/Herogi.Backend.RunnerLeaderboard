using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Herogi.Leaderboard.Data.Entity
{
    public class BaseEntity
    {
        [BsonId]
        [BsonElement("Id")]
        public int Id { get; set; }
    }
}
