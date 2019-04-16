using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBCore.Repositories
{
    public abstract class EntityBase
    {
        [BsonId]
        public Guid Id { get; set; }
        public string UniqKey { get; set; }
    }
}
