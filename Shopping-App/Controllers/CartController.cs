using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_App.Data;
using Shopping_App.Models;

namespace Shopping_App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart>> getCart(string userId)
        {
            return await _context.Carts.Where(o => o.UserId == userId).FirstOrDefaultAsync();
        }

        [HttpGet("product-count/{userId}")]
        public async Task<ActionResult<int>> productCount(string userId)
        {
            var cart = await _context.Carts.Where(o => o.UserId == userId).FirstOrDefaultAsync();

            return Ok(cart.Products.Count());
        }

        [HttpPost("assign-new-cart-to-user/{userId}")]
        public async Task<ActionResult<Cart>> createCart(string userId)
        {
            var existingCart = await _context.Carts.Where(o => o.UserId == userId).FirstOrDefaultAsync();

            if(existingCart == null)
            {
                var cart = new Cart()
                {
                    UserId = userId,
                    ProductId = 0,
                };

                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();

                return Ok(cart);
            }

            return Ok(existingCart);
        }

        [HttpPost("add-quantity-of-a-product/{productId}/{userId}/{newQuantity}")]
        public async Task<ActionResult<Cart>> addQuantityOfProduct(int productId, string userId, int newQuantity)
        {
            var cart = await _context.Carts.Where(h => h.UserId == userId).FirstOrDefaultAsync();

            var product = cart.Products.Where(u => u.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                int productIndex = cart.Products.IndexOf(product);

                Product newProduct = new Product
                {
                    ProductId = productId,
                    Quantity = newQuantity,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    PhotoUrl1 = product.PhotoUrl1,

                };

                cart.Products[productIndex] = newProduct;
            }

            await _context.SaveChangesAsync();

            return Ok(cart);

        }


    }
}
