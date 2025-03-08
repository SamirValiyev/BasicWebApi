using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApiConsume.Models
{
    public class ProductRequest
    {

        //       "name": "string",
        //"id": 0,
        //"stock": 0,
        //"price": 0,
        //"createdDate": "2025-02-28T06:20:22.444Z",
        //"imagePath": "string",
        //"categoryId": 0

        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ImagePath { get; set; } = null;
        public int CategoryId { get; set; }



        //public string? Name { get; set; }
        //public int Stock { get; set; }
        //public decimal Price { get; set; }

        //public DateTime CreatedDate { get; set; } = DateTime.Now;

        //public string? ImagePath { get; set; }

        //public int CategoryId { get; set; }
    }
}
