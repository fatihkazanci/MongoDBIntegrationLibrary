using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBCore.Repositories
{
    public class DeleteResponse : ResponseBase
    {
        public DeleteResult DeleteResult { get; set; }
    }
}
