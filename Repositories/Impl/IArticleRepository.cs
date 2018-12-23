using Common;
using Models;
using System;

namespace Repositories.Impl
{
    public interface IArticleRepository:IRepository<Article>
    {

    }
    public class ArticleRepository:Repository<Article>,IArticleRepository
    {
        public ArticleRepository(IDatabaseFactory factory,AppSettings settings) : base(factory,settings)
        {

        }




    }
}
