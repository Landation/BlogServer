using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public interface ITagRepository : IRepository<Tag>
    {

    }
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(IDatabaseFactory factory, AppSettings settings) : base(factory, settings)
        {
        }

    }
}
