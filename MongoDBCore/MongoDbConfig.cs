using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBCore
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
