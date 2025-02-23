using BasicWebApi.Data.Common;
using BasicWebApi.Data.Context;
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
        public async Task<IList<T>> GetAllAsync()
        {
            var data= await _dbSet.ToListAsync();
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data =await _dbSet.SingleOrDefaultAsync(x=>x.Id==id);
            return data;
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
