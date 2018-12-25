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
    public class HeroController:BaseController
    {
        private IHeroService _heroService;
        private IHostIPProvider _provider;
        public HeroController(IHeroService heroService, IHostIPProvider provider)
        {
            _provider = provider;
            _heroService = heroService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]HeroDTO dto)
        {
            var remote = await _provider.GetRemote(Request);
            var result = await _heroService.AddHero(dto, remote);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _heroService.GetHeros();
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var result = await _heroService.DeleteHero(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute]string id, [FromBody]HeroDTO dto)
        {
            var result = await _heroService.UpdateHero(id, dto);
            return Ok(result);
        }

    }
}
