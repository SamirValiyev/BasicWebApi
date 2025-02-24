using BasicWebApi.Data.Common;

namespace BasicWebApi.Data.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class,IEntityBase
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
      
        Task RemoveAsync(int id);
    }
}
