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

            if (existingCart == null)
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

        [HttpPost("change-quantity-of-a-product/{itemId}/{newQuantity}")]
        public async Task<ActionResult<Cart>> addQuantityOfProduct(int itemId, int newQuantity)
        {
            var cartItem = await _context.CartItems.Where(u => u.ItemId == itemId).FirstOrDefaultAsync();

            cartItem.ItemQuantity = newQuantity;

            await _context.SaveChangesAsync();

            return Ok(cartItem);

        }

        [HttpGet("get-all-cart-items/{cartId}")]
        public async Task<ActionResult<List<CartItems>>> getAllCartItems(int cartId)
        {

            var cartItems = await _context.CartItems.Where(u => u.CartId == cartId).ToListAsync();

            return Ok(cartItems);

        }

        [HttpGet("get-one-cart-item/{itemId}")]
        public async Task<ActionResult<List<CartItems>>> getOneCartItem(int itemId)
        {

            var cartItem = await _context.CartItems.Where(u => u.ItemId == itemId).FirstOrDefaultAsync();

            return Ok(cartItem);

        }

        [HttpGet("get-cart-total/{cartId}")]
        public async Task<ActionResult<double>> GetCartTotal(int cartId)
        {
            var cart = await _context.Cart.Include(c => c.CartItems)
                                          .Where(u => u.CartId == cartId)
                                          .FirstOrDefaultAsync();

            if (cart == null)
            {
                return NotFound($"Cart with ID {cartId} not found.");
            }

            double total = 0;

            foreach (var item in cart.CartItems)
            {
                item.ItemTotal = item.ItemPrice * item.ItemQuantity;
                total += item.ItemTotal;
            }

            cart.TotalPrice = total;

            await _context.SaveChangesAsync();

            return Ok(cart.TotalPrice);
        }


    }



}
