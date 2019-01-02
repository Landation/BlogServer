using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host.Controllers
{
    public class ArticleController : BaseController
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ArticleDTO dto)
        {
            var result = await _articleService.AddArticle(dto);
            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<ArticleDTO> result = null;
            if (Request.Query["tag"].Any())
            {
                var tag = Request.Query["tag"].First();
                result = await _articleService.GetArticlesByTag(tag);
            }
            else
            {
                result = await _articleService.GetArticleAll();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute]string id)
        {
            var result = await _articleService.GetArticleById(id);
            return Ok(result);
        }



        [HttpGet("next/{lastId}")]
        public async Task<ActionResult> GetNext([FromRoute]string lastId)
        {
            var result = await _articleService.GetNextArticles(lastId);
            return Ok(result);
        }

        [HttpPut("like/{id}")]
        public async Task<ActionResult> Put([FromRoute]string id)
        {
            var result = await _articleService.AddArticleLike(id);
            return Ok(result);
        }



        [HttpGet("hot")]
        public async Task<ActionResult> GetHot()
        {
            var result = await _articleService.GetHotArticles();
            return Ok(result);
        }







    }
}
