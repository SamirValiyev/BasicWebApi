using BasicWebApi.Data.Entities;
using BasicWebApi.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
             _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
           
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Product product)
        {
            var newProduct = await _productRepository.CreateAsync(product);
            if (string.IsNullOrWhiteSpace(product.ImagePath))
            {
                product.ImagePath = null;   
            }
            return Created(string.Empty, newProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var checkProduct = await _productRepository.GetByIdAsync(product.Id);
            if (checkProduct == null)
            {       
                return NotFound(product.Id);
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var checkProduct = await _productRepository.GetByIdAsync(id);
            if (checkProduct == null)
            {
                return NotFound(id);
            }
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var newFileName=Guid.NewGuid()+ "." +Path.GetExtension(file.FileName); 
            var path=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newFileName); 
            var stream=new FileStream(path,FileMode.Create); 
            await file.CopyToAsync(stream);
            return Created(string.Empty,file);
        }

    }
}
