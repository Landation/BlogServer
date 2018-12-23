using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class IEntity
    {
        [BsonId(IdGenerator =typeof(StringObjectIdGenerator))]
        [BsonRequired]
        public string Id { get; set; }
    }
}
