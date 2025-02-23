using BasicWebApi.Data.Context;
using BasicWebApi.Data.Entities;
using BasicWebApi.Data.Repositories.Abstract;

namespace BasicWebApi.Data.Repositories.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
