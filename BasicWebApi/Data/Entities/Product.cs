using BasicWebApi.Data.Common;

namespace BasicWebApi.Data.Entities
{
    public class Product:EntityBase
    {
        public  int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ImagePath { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
