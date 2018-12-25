using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Impl
{
    public interface IHeroRepository : IRepository<Hero>
    {

    }
    public class HeroRepository : Repository<Hero>, IHeroRepository
    {
        public HeroRepository(IDatabaseFactory factory, AppSettings settings) : base(factory, settings)
        {
        }

    }
}
