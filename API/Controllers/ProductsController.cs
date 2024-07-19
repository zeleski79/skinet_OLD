using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
       
        private readonly StoreContext _context; // private field should start with a "_"

        public ProductsController(StoreContext context)
        {
            _context = context;      
        }

        [HttpGet] 
        public async Task<ActionResult<List<Product>>> getProducts() {
                return  await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> getProduct(int id) {
                return await _context.Products.FindAsync(id);
        }
    }
}