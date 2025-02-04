using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity.Common;
using Final_CFF.Core.Repositories;
using Final_CFF.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Final_CFF.DAL.Repositories
{
    public class GenericRepository<T>(FinalDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public IQueryable<T> GetAll()
            => Table.AsQueryable();

        public async Task<T?> GetByIdAsync(Guid id)
            => await Table.FindAsync(id);

        public async Task<bool> IsExistAsync(Guid id)
            => await Table.AnyAsync(x=> x.Id == id);


        public void Remove(T entity)
            => Table.Remove(entity);

        public async Task<bool> RemoveAsync(Guid id)
        {
            int result = await Table.Where(x => x.Id == id).ExecuteDeleteAsync();
            return result > 0;
        }
     
        public async Task SaveAsync()
            => await _context.SaveChangesAsync();

    }
}
