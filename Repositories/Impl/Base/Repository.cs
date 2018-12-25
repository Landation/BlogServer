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
        protected readonly IMongoDatabase _db;
        protected readonly IMongoCollection<T> _collection;
        public Repository(IDatabaseFactory factory,AppSettings settings)
        {
            var config = settings.MongoDB;
            _db = factory.GetClient(config.ConnectionString).GetDatabase(config.Database);
            _collection = _db.GetCollection<T>(typeof(T).Name);
        }


        public async Task<T> Get(string id)
        {
            return  await this._db.GetCollection<T>(typeof(T).Name).Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {

            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> predicate)
        {

            return  await _collection.Find(predicate).AnyAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await this._collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate)
        {



            var listAsync = await _collection.Find(predicate).ToListAsync();

            return listAsync;
        }

        public async Task<T> Save(T entity)
        {


            await _collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
            {
                IsUpsert = true
            });

            return entity;
        }

        public async Task<T> Add(T entity)
        {

            await _collection.InsertOneAsync( entity);
            return entity;
        }




        
        public async Task<bool> Delete(string id)
        {

            var result = await _collection.DeleteOneAsync(x => x.Id.Equals(id));
            return result.DeletedCount > 0;
        }

        public async Task Delete(T entity)
        {

            await _collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }




    }
}
