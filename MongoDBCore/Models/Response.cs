using MongoDBCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBCore.Models
{
    public class Response : ResponseBase
    {
        public string UniqKey { get; set; }
    }
}
