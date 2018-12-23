using AutoMapper;
using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Contracts
{
   public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project,ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
