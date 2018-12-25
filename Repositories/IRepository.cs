using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T> where T : IEntity
    {

        Task<T> Get(string id);

        Task<T> Find(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAll();

        Task<bool> Exist(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate);

        Task<T> Save(T entity);

        Task<bool> Delete(string id);

        Task Delete(T entity);

        Task<T> Add(T entity);


    }
}
