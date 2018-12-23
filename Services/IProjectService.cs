using AutoMapper;
using Common;
using Common.CustomExceptions;
using Contracts.DTO;
using Models;
using Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IProjectService
    {
        Task<Project> AddProject(ProjectDTO dto);
        Task<IEnumerable<ProjectDTO>> GetAllProject();
        Task<ProjectDTO> GetProjectById(string id);
        Task<bool> DeleteById(string id);
        Task<Project> SaveProject(string id, ProjectDTO dto);

    }

    public class ProjectService : IProjectService
    {

        private IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> AddProject(ProjectDTO dto)
        {
            var project = Mapper.Map<ProjectDTO, Project>(dto);
            return await _projectRepository.Add(project);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProject()
        {

            var projects = await _projectRepository.GetAll();
            var dtos = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(projects);
            return dtos;
        }

        public async Task<ProjectDTO> GetProjectById(string id)
        {
            var project = await _projectRepository.Get(id);
            var dto = Mapper.Map<Project, ProjectDTO>(project);
            return dto;
        }


        public async Task<bool> DeleteById(string id)
        {
            var project = await _projectRepository.Get(id);
            if (project != null)
            {
                await _projectRepository.Delete(id);
                return true;
            }
            else
            {
                throw new BusinessException(ResultCode.BADREQUEST, "删除的项目不存在");
            }
        }

        public async Task<Project> SaveProject(string id,ProjectDTO dto)
        {
            var project = Mapper.Map<ProjectDTO, Project>(dto);
            var result =  await _projectRepository.Get(id);
            if (result == null)
            {
                throw new BusinessException(ResultCode.BADREQUEST, "保存的项目不存在");
            }
            else
            {
                project.Id = id;
               return await _projectRepository.Save(project);
            }



        }




    }
}
