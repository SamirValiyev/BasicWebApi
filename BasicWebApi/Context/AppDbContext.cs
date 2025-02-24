using BasicWebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasKey(p => p.Id);


            //modelBuilder.Entity<Product>()
            //            .Property(p => p.Id)
            //            .ValueGeneratedOnAdd();


            modelBuilder.Entity<Product>()
                        .Property(p => p.Price)
                        .HasColumnType("decimal(16,2)")
                        .IsRequired();

            modelBuilder.Entity<Product>()
                        .Property(p => p.Name)
                        .IsRequired()
                        .HasMaxLength(40);


            modelBuilder.Entity<Product>()
                        .HasData(new Product[]
                        {
                            new Product{Id=1,Name="Iphone 12",Price=1000,Stock=100,CreatedDate=DateTime.Now.AddDays(-3)},
                            new Product{Id=2,Name="Acer Laptop",Price=2000,Stock=50,CreatedDate=DateTime.Now.AddDays(-5)},
                            new Product {Id=3, Name = "Samsung S21", Price = 1500, Stock = 200, CreatedDate = DateTime.Now.AddDays(-2) }
                        });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Product { get; set; }
    }
}
