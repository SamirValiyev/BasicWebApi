using BasicWebApi.Data.Common;
using System.Text.Json.Serialization;

namespace BasicWebApi.Data.Entities
{
    public class Product:EntityBase
    {
        [JsonIgnore]
        public new int Id { get; set; }
        public  int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ImagePath { get; set; }
        public int? CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
    }
}
