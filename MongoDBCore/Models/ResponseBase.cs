using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBCore.Repositories
{
    public abstract class ResponseBase
    {
        public bool Result { get; set; }
        public Exception Exception { get; set; }
    }
}
