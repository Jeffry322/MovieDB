using Domain.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> FirstOrDeffaultAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(predicate);
            if (result == null) throw new EntityNotFoundException();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result == null) throw new EntityNotFoundException(typeof(T).Name, id);

            return result;
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            if (result == null || result.Count == 0) throw new EntityNotFoundException();
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}