using Common;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<List<Article>> GetNextArticles(string lastId, int pageSize = 10);

        Task<List<Article>> GetHotArticles();

        Task<Article> AddArticleLike(string id);

        Task<Article> AddArticleComment(string id);


    }
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(IDatabaseFactory factory, AppSettings settings) : base(factory, settings)
        {

        }

        public override async Task<IEnumerable<Article>> GetAll()
        {
            SortDefinitionBuilder<Article> builderSort = Builders<Article>.Sort;
            var sort = builderSort.Descending("_id");
            var options = new FindOptions<Article, Article>()
            {
                Sort = sort,
            };
            var cursor = await this._collection.FindAsync(new BsonDocument(), options);
            return await cursor.ToListAsync();
        }


        public async Task<List<Article>> GetNextArticles(string lastId, int pageSize = 10)
        {
            var filter = Builders<Article>.Filter.Lt("_id", lastId);
            SortDefinitionBuilder<Article> builderSort = Builders<Article>.Sort;
            var sort = builderSort.Descending("_id");
            var options = new FindOptions<Article, Article>()
            {
                Sort = sort,
                Limit = pageSize
            };
            var cursor = await this._collection.FindAsync(filter, options);
            return await cursor.ToListAsync();
        }


        public async Task<List<Article>> GetHotArticles()
        {
            SortDefinitionBuilder<Article> builderSort = Builders<Article>.Sort;
            var sort = builderSort.Descending("Meta.Views");
            var options = new FindOptions<Article, Article>()
            {
                Sort = sort,
                Limit = 10
            };
            var cursor = await this._collection.FindAsync(new BsonDocument(), options);
            return await cursor.ToListAsync();
        }

        public async Task<Article> AddArticleLike(string id)
        {
            var article =await Get(id);
            article.Meta.Likes += 1;
            return await Save(article);
        }

        public async Task<Article> AddArticleComment(string id)
        {
            var article = await Get(id);
            article.Meta.Comments += 1;
            return await Save(article);
        }


    }
}
