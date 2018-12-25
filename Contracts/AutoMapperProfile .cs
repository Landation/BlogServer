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

            CreateMap<Article, ArticleDTO>();
            CreateMap<ArticleDTO, Article>();

            CreateMap<Comment, CommentDTO>()
                .ForMember(d=>d.Author,op=>op.MapFrom<Comment>(s=> null));
            CreateMap<CommentDTO, Comment>();

            CreateMap<TagDTO, Tag>();
            CreateMap<Tag, TagDTO>();
            CreateMap<HeroDTO, Hero>();
            CreateMap<Hero, HeroDTO>();
        }
    }
}
