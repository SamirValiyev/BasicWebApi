using BasicWebApi.Data.Common;
using BasicWebApi.Data.Context;
using BasicWebApi.Data.Entities;
using BasicWebApi.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Data.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,IEntityBase
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context; 
            _dbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            var data= await _dbSet.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data =await _dbSet.AsNoTracking().SingleOrDefaultAsync(x=>x.Id==id);
            return data;
        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _dbSet.FindAsync(id);
             _dbSet.Remove(removedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var data = await _dbSet.FindAsync(entity.Id);
            _context.Entry(data).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
