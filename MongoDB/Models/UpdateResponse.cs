using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Models
{
    public class UpdateResponse : ResponseBase
    {
        public UpdateResult UpdateResult { get; set; }
    }
}
