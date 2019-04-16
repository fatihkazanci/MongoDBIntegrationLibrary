using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBCore.Repositories
{
    public class UpdateResponse : ResponseBase
    {
        public UpdateResult UpdateResult { get; set; }
    }
}
