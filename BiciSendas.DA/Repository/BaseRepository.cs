using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext DbContext;

        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public List<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
