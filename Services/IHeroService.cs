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
    public interface IHeroService
    {
        Task<HeroDTO> AddHero(HeroDTO dto, RemoteInfo remote);
        Task<IEnumerable<HeroDTO>> GetHeros();
        Task<bool> DeleteHero(string id);
        Task<HeroDTO> UpdateHero(string id, HeroDTO dto);
    }
   public class HeroService: IHeroService
    {
        private IHeroRepository _heroRepository;
        public HeroService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }




        public async Task<HeroDTO> AddHero(HeroDTO dto, RemoteInfo remote)
        {
            var hero = Mapper.Map<HeroDTO, Hero>(dto);
            hero.Remote = remote;
            await _heroRepository.Add(hero);
            return dto;
        }

        public async Task<IEnumerable<HeroDTO>> GetHeros()
        {
            var heros = await _heroRepository.GetAll();
            var dtos = Mapper.Map<IEnumerable<Hero>, IEnumerable<HeroDTO>>(heros);
            return dtos;
        }



        public async Task<bool> DeleteHero(string id)
        {
            var exist = await _heroRepository.Exist(x => x.Id == id);
            if (exist)
            {
                return await _heroRepository.Delete(id);
            }
            else
            {
                throw new BusinessException(ResultCode.BADREQUEST, "留言名不存在");
            }
        }

        public async Task<HeroDTO> UpdateHero(string id, HeroDTO dto)
        {

            if (await _heroRepository.Exist(x => x.Id == id))
            {
                var hero = Mapper.Map<HeroDTO, Hero>(dto);
                hero.Id = id;
                await _heroRepository.Save(hero);
                return dto;
            }
            else
            {
                throw new BusinessException(ResultCode.BADREQUEST, "标签名已经存在");
            }

        }



    }
}
