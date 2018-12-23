using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Impl
{
    public interface IDatabaseFactory
    {
        IMongoClient GetClient(string connection);
    }
    public class DatabaseFactory : IDatabaseFactory
    {
        public IMongoClient GetClient(string connection)
        {
            return new MongoClient(connection);
        }
    }
}
