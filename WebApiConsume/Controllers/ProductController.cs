using Microsoft.AspNetCore.Mvc;
using WebApiConsume.Services;

namespace WebApiConsume.Controllers
{
    public class ProductController:Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

    }
}
