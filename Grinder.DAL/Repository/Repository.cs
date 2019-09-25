using Grinder.DAL.DB;
using Grinder.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private GrinderContext db;
        DbSet<T> dbSet;
        public Repository(GrinderContext context)
        {
            db = context;
            dbSet = context.Set<T>();
        }

        public async Task Create(T item)
        {
           await dbSet.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            T item = await dbSet.FindAsync(id);
            if (item!=null)
            {
                dbSet.Remove(item);
            }
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
