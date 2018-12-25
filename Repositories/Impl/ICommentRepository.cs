using Common;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public interface ICommentRepository: IRepository<Comment>
    {
        Task<List<Comment>> GetCommentByPostId(string postId);
        Task<Comment> AddCommentLike(string id);
    }
    public class CommentRepository:Repository<Comment>, ICommentRepository
    {
        public CommentRepository(IDatabaseFactory factory, AppSettings settings) : base(factory, settings)
        {

        }

        public async Task<List<Comment>> GetCommentByPostId(string postId)
        {
            var filter = Builders<Comment>.Filter.Eq("PostId", postId);
            SortDefinitionBuilder<Comment> builderSort = Builders<Comment>.Sort;
            var sort = builderSort.Descending("_id");
            var options = new FindOptions<Comment, Comment>()
            {
                Sort = sort,
            };
            var cursor = await this._collection.FindAsync(filter, options);
            return await cursor.ToListAsync();
        }

        public async Task<Comment> AddCommentLike(string id)
        {
            var comment = await Get(id);
            comment.Likes += 1;
            return await Save(comment);
        }




    }
}
