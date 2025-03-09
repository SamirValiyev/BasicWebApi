using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApiConsume.Models
{
    public class ProductRequest
    {

        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        //public CategoryRequest CategoryRequest { get; set; }

    }
}
