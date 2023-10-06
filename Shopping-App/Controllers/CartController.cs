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


    }
}
