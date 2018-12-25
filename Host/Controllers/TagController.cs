using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host.Controllers
{
    public class TagController:BaseController
    {
        private ITagService _tagService;
        public TagController(ITagService tagService)
        {
            this._tagService = tagService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]TagDTO dto)
        {
            var result = await _tagService.Add(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _tagService.GetAllTags();
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var result = await _tagService.DeleteTags(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute]string id, [FromBody]TagDTO dto)
        {
            var result = await _tagService.UpdateTag(id, dto);
            return Ok(result);
        }





    }
}
