using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Impl
{
    public interface IProjectRepository : IRepository<Project>
    {

    }
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(IDatabaseFactory factory,AppSettings settings) : base(factory,settings)
        {

        }




    }
}
