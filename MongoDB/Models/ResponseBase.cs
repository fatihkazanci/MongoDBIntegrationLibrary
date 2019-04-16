using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Models
{
    public abstract class ResponseBase
    {
        public bool Result { get; set; }
        public Exception Exception { get; set; }
    }
}
