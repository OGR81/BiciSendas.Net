using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetById(int id);
        Task<T?> GetById(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
