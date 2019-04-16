using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Models
{
    public class UpdateListResponse : ResponseBase
    {
        public List<UpdateResult> UpdateResultList { get; set; }
    }
}
