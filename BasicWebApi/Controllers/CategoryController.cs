using BasicWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProduct(int id)
        {
            var data = await _categoryRepository.GetProductsWithCategoryIdAsync(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);
        }
    }
}
