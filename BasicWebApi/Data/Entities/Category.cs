using BasicWebApi.Data.Common;

namespace BasicWebApi.Data.Entities
{
    public class Category:EntityBase
    {
        public IList<Product>? Products { get; set; }
    }
}
