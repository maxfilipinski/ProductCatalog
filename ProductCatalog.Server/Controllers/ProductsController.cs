using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Server.Models;
using ProductCatalog.Server.Services;

namespace ProductCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _productsService.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productsService.GetProduct(id);
            if (product == null)
                return NotFound("Product not found.");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct(Product product)
        {
            return Ok(await _productsService.CreateProduct(product));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(Product newProduct)
        {
            var product = await _productsService.UpdateProduct(newProduct);
            if (product == null)
                return BadRequest("Product not found.");

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var isDeleted = await _productsService.DeleteProduct(id);

            return isDeleted ? Ok(isDeleted) : BadRequest("Product not found.");
        }
    }
}
