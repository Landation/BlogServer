using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using Providers;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentService _commentService;
        private IHostIPProvider _provider;
        public CommentController(ICommentService commentService, IHostIPProvider provider)
        {
            _commentService = commentService;
            _provider = provider;
        }
        [HttpGet("{aid}")]
        public async Task<ActionResult> Get([FromRoute]string aid)
        {
            var comments = await _commentService.GetCommentByPostId(aid);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CommentDTO dto)
        {
            var remote = await _provider.GetRemote(Request);
            var comments = await _commentService.AddComment(dto, remote);
            return Ok(comments);
        }


        [HttpPut("like/{id}")]
        public async Task<ActionResult> Put([FromRoute]string id)
        {
            var comment = await _commentService.LikeComment(id);
            return Ok(comment);
        }







    }
}
