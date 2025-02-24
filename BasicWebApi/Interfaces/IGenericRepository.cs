using BasicWebApi.Data.Common;

namespace BasicWebApi.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntityBase
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(int id);
    }
}
