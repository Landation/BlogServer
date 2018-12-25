using AutoMapper;
using Contracts.DTO;
using Models;
using Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDTO>> GetArticleAll();
        Task<ArticleDTO> GetArticleById(string id);
        Task<IEnumerable<ArticleDTO>> GetNextArticles(string lastId);





        Task<IEnumerable<ArticleDTO>> GetHotArticles();


        Task<ArticleDTO> AddArticleLike(string id);

        Task<ArticleDTO> AddArticle(ArticleDTO dto);






    }

    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleDTO> AddArticle(ArticleDTO dto)
        {
            var article = Mapper.Map<ArticleDTO, Article>(dto);
            await _articleRepository.Add(article);
            return dto;
        }


        public async Task<IEnumerable<ArticleDTO>> GetArticleAll()
        {
            var articles = await _articleRepository.GetAll();
            var dtos = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
            return dtos;
        }

        public async Task<ArticleDTO> GetArticleById(string id)
        {
            var article = await _articleRepository.Get(id);
            article.Meta.Views += 1;
            await _articleRepository.Save(article);
            var dto = Mapper.Map<Article, ArticleDTO>(article);
            return dto;
        }

        public async Task<IEnumerable<ArticleDTO>> GetNextArticles(string lastId)
        {
            var articles = await _articleRepository.GetNextArticles(lastId);
            var dtos = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
            return dtos;
        }


        public async Task<IEnumerable<ArticleDTO>> GetHotArticles()
        {
            var articles = await _articleRepository.GetHotArticles();
            var dtos = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
            return dtos;
        }

        public async Task<ArticleDTO> AddArticleLike(string id)
        {
            var article = await _articleRepository.AddArticleLike(id);
            var dto = Mapper.Map<Article, ArticleDTO>(article);
            return dto;
        }




    }


}
