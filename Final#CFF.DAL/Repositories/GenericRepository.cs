using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, bool asNoTrack = true, params string[] includes)
        {
            return await _includeAndTracking(Table.Where(expression), asNoTrack, includes).FirstOrDefaultAsync();
        }


        public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            return await GetFirstAsync(expression, true, includes);
        }

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



        IQueryable<T> _chechkIncludes(IQueryable<T> query, params string[] includes)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query;
        }

        IQueryable<T> _includeAndTracking(IQueryable<T> query, bool asNoTrack, params string[] includes)
        {
            if (includes is not null && includes.Length > 0)
            {
                query = _chechkIncludes(query, includes);
                if (asNoTrack)
                    query = query.AsNoTrackingWithIdentityResolution();
            }
            else
            {
                if (asNoTrack)
                    query = query.AsNoTracking();
            }
            return query;
        }
    }
}
