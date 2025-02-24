using BasicWebApi.Context;
using BasicWebApi.Data.Entities;
using BasicWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
       
        public ProductRepository(AppDbContext context) : base(context)
        {
           
        }

       
    }
}
