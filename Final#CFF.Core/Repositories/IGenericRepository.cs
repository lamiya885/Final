using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity.Common;

namespace Final_CFF.Core.Repositories
{
    public  interface IGenericRepository<T> where T:BaseEntity,new()
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task<bool> IsExistAsync(Guid id);
        void Remove(T entity);
        Task<bool> RemoveAsync(Guid id);
        Task SaveAsync();
    }
}
