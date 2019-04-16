using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBCore.Repositories
{
    public class UpdateListResponse : ResponseBase
    {
        public List<UpdateResult> UpdateResultList { get; set; }
    }
}