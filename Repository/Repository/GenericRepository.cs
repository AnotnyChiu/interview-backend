using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GenericRepository<TEntity, TContext>
    where TContext : DbContext
    where TEntity : class
    {
        protected readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }

        // CRUD operations
        public async Task AddAsync(TEntity model)
        {
            await _context.Set<TEntity>().AddAsync(model);
            await SaveAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();

        public async virtual Task<TEntity> GetByIdAsync(int id)
            => await _context.Set<TEntity>().FindAsync(id);

        // have to do update logic in repository
        public async virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveAsync();
            return entity;
        }

        // can pass Id only to remove the object
        public async Task Remove(TEntity entity)
        {
            // check exist
            if (_context.Set<TEntity>().Find(entity) != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await SaveAsync();
            }
            else
            {
                Console.WriteLine("Object Id not exist");
                return;
            }
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
