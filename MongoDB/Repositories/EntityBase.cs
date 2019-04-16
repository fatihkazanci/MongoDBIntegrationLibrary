using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Repositories
{
    public abstract class EntityBase
    {
        [BsonId]
        public Guid Id { get; set; }
        public string UniqKey { get; set; }
    }
}
