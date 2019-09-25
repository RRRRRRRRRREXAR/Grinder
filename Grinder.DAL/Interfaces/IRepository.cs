using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.DAL.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T,bool>> expression);
    }
}
