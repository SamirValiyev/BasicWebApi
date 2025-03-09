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
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.UpdateProductAsync(id);
            if (product != null)
            {
                // TempData["Success"] = "Product updated successfully";
                return View(product);
            }
            else
            {
                // TempData["Error"] = "Error updating product";
                return View(null);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductResponse productResponse)
        {
            var product = await _productService.UpdateProductAsync(productResponse);
            if (product != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Error updating product";
                return View(productResponse);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteProduct = await _productService.RemoveProductAsync(id);
            if (deleteProduct != null)
            {
                return RedirectToAction("Index");
            }
            return View(null);
        }
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var upload = await  _productService.UploadAsync(file);
            if (upload)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
