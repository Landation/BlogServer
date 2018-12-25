using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using Host.Attributes;
using Microsoft.AspNetCore.Mvc;
using Providers;
using Services;

namespace Host.Controllers
{

    public class ProjectController : BaseController
    {
        private IProjectService _projectService;
        private IHostIPProvider _iPProvider;
        public ProjectController(IProjectService projectService,IHostIPProvider iPProvider)
        {
            this._projectService = projectService;
            this._iPProvider = iPProvider;

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ProjectDTO dto)
        {
            var result = await _projectService.AddProject(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _projectService.GetAllProject();
            var remote = await _iPProvider.GetRemote(Request);
            return Ok(remote);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] string id)
        {
            var result = await _projectService.GetProjectById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var result = await _projectService.DeleteById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute]string id,[FromBody]ProjectDTO dto)
        {
            var result = await _projectService.SaveProject(id,dto);
            return Ok(result);
        }



    }
}
