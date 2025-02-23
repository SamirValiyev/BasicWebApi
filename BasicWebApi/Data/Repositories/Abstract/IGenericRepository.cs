using BasicWebApi.Data.Common;

namespace BasicWebApi.Data.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class,IEntityBase
    {
        Task<IList<T>> GetAllAsync();
        Task<int> SaveChangesAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
    }
}
