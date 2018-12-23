using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
   public class AppSettings
    {

        public  MongoDBConfiguration MongoDB { get; set; }
        public class MongoDBConfiguration
        {
            public string ConnectionString { get; set; }
            public string Database { get; set; }
        }
    }
}
