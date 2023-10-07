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
            return await _context.Cart.Where(o => o.UserId == userId).FirstOrDefaultAsync();
        }

        [HttpGet("product-count/{userId}/{cartId}")]
        public async Task<ActionResult<int>> productCount(string userId, int cartId)
        {
            var cartItems = await _context.CartItems.Where(o => o.CartId == cartId && o.UserId == userId).ToListAsync();

            if (cartItems == null)
            {
                return NotFound("Cart Items not found for the given user ID.");
            }


            return Ok(cartItems.Count());
        }

        [HttpPost("assign-new-cart-to-user/{userId}")]
        public async Task<ActionResult<Cart>> createCart(string userId)
        {
            var existingCart = await _context.Cart.Where(o => o.UserId == userId).FirstOrDefaultAsync();

            if(existingCart == null)
            {
                //var random = new Random();
                //int unkownId = random.Next(1, 1000000);

                var cart = new Cart()
                {
                    UserId = userId,
                };

                _context.Cart.Add(cart);
                await _context.SaveChangesAsync();

                return Ok(cart);
            }

            return Ok(existingCart);
        }

        //[HttpPost("add-quantity-of-a-product/{productId}/{userId}/{newQuantity}")]
        //public async Task<ActionResult<Cart>> addQuantityOfProduct(int productId, string userId, int newQuantity)
        //{
        //    var cart = await _context.Cart.Where(h => h.UserId == userId).FirstOrDefaultAsync();

        //    var product = await _context.Products.Where(u => u.ProductId == productId).FirstOrDefaultAsync();

        //    if (product != null)
        //    {
        //        int productIndex = cart.CartItems.IndexOf(product);

        //        var cartItem = new CartItems
        //        {

        //            ItemName = product.ProductName,
        //            Description = product.Description,
        //            ItemPhotoUrl = product.PhotoUrl1,
        //            ItemPrice = product.Price,
        //            ItemQuantity = product.Quantity,
        //        };

        //        cart.CartItems[productIndex] = newProduct;
        //    }

        //    await _context.SaveChangesAsync();

        //    return Ok(cart);

        //}


    }
}
