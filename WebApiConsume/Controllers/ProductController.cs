using Microsoft.AspNetCore.Mvc;
using WebApiConsume.Models;
using WebApiConsume.Services;

namespace WebApiConsume.Controllers
{
    public class ProductController : Controller
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest productRequest)
        {
            var products = await _productService.CreateProductAsync(productRequest);

            if (products != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Error creating product";
                return View(productRequest);
            }
        }
    }
}
