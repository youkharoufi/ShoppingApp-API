using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_App.Data;
using Shopping_App.Models;

namespace Shopping_App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;


        public ProductsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("get-all-products")]
        public async Task<ActionResult<List<Product>>> getAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("get-one-product/{productId}")]
        public async Task<ActionResult<Product>> getOneProduct(int productId)
        {
            var product = await _context.Products.Where(o => o.ProductId == productId).FirstOrDefaultAsync();

            return Ok(product);
        }
    }
}
