using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB
{
    public class MongoDbConfig
    {
        internal static string ConnectionString { get; set; }
        internal static string DatabaseName { get; set; }
        public static void DefaultConnection(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }
    }
}
