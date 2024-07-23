using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
 
        private readonly IProductRepository _repo;
       
        public ProductsController(IProductRepository repo) {
            _repo = repo;
        }

        [HttpGet] 
        public async Task<ActionResult<IReadOnlyList<Product>>> getProducts() {
            var products = await _repo.getProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> getProduct(int id) {
            return await _repo.getProductByIdAsync(id);
        }
    }
}