using AutoMapper;
using Common;
using Common.CustomExceptions;
using Contracts.DTO;
using Models;
using Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITagService
    {
        Task<TagDTO> Add(TagDTO dto);
        Task<IEnumerable<TagDTO>> GetAllTags();
        Task<bool> DeleteTags(string id);
        Task<TagDTO> UpdateTag(string id, TagDTO dto);
    }
    public class TagService : ITagService
    {
        private ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagDTO> Add(TagDTO dto)
        {

            if (!await _tagRepository.Exist(x => x.Name == dto.Name))
            {
                var tag = Mapper.Map<TagDTO, Tag>(dto);
                await _tagRepository.Add(tag);
                return dto;
            }
            else
            {
                throw new BusinessException(ResultCode.BADREQUEST, "标签名已经存在");
            }

        }

        public async Task<IEnumerable<TagDTO>> GetAllTags()
        {
            var tags = await _tagRepository.GetAll();
            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagDTO>>(tags);
        }

        public async Task<bool> DeleteTags(string id)
        {
            var exist = await _tagRepository.Exist(x=>x.Id == id);
            if (exist)
            {
               return await _tagRepository.Delete(id);
            }
            else
            {
                throw new BusinessException(ResultCode.BADREQUEST, "标签名不存在");
            }
        }

        public async Task<TagDTO> UpdateTag(string id,TagDTO dto)
        {

            if (await _tagRepository.Exist(x => x.Id == id))
            {
                var tag = Mapper.Map<TagDTO, Tag>(dto);
                tag.Id = id;
                tag.UpdateAt = DateTime.Now;
                await _tagRepository.Save(tag);
                return dto;
            }
            else
            {
                throw new BusinessException(ResultCode.BADREQUEST, "标签名已经存在");
            }

        }








    }
}
