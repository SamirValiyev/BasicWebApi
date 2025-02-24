using BasicWebApi.Data.Entities;

namespace BasicWebApi.Interfaces
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<IList<Product>> GetProductsWithCategoryIdAsync(int categoryId);
    }
}
