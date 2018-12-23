using Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IArticleService
    {
    }

    public class ArticleService:IArticleService
    {
        private IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
    }


}
