using Common;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{

   public class Repository<T>:IRepository<T> where T:IEntity
    {
        protected readonly IMongoDatabase _dbContext;
        protected readonly IMongoCollection<T> _dbSet;
        public Repository(IDatabaseFactory factory,AppSettings settings)
        {
            var config = settings.MongoDB;
            _dbContext = factory.GetClient(config.ConnectionString).GetDatabase(config.Database);
            _dbSet = _dbContext.GetCollection<T>(typeof(T).Name);
        }


        public async Task<T> Get(string id)
        {
            return  await this._dbContext.GetCollection<T>(typeof(T).Name).Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            var collection = this._dbContext.GetCollection<T>(typeof(T).Name);

            return await collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._dbContext.GetCollection<T>(typeof(T).Name).Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate)
        {

            var collection = this._dbContext.GetCollection<T>(typeof(T).Name);

            var listAsync = await collection.Find(predicate).ToListAsync();

            return listAsync;
        }

        public async Task<T> Save(T entity)
        {
            var collection = this._dbContext.GetCollection<T>(typeof(T).Name);

            await collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
            {
                IsUpsert = true
            });

            return entity;
        }

        public async Task<T> Add(T entity)
        {
            var collection = this._dbContext.GetCollection<T>(typeof(T).Name);
            await collection.InsertOneAsync( entity);
            return entity;
        }



        
        public async Task<bool> Delete(string id)
        {
            var collection = this._dbContext.GetCollection<T>(typeof(T).Name);
            var result = await collection.DeleteOneAsync(x => x.Id.Equals(id));
            return result.DeletedCount > 0;
        }

        public async Task Delete(T entity)
        {
            var collection = this._dbContext.GetCollection<T>(typeof(T).Name);
            await collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }




    }
}
