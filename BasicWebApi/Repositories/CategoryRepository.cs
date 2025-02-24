using BasicWebApi.Context;
using BasicWebApi.Data.Entities;
using BasicWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IList<Product>> GetProductsWithCategoryIdAsync(int categoryId)
        {
            var data = await _context.Category.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
            return data?.Products.ToList() ?? new List<Product>();
           

        }
    }
}
