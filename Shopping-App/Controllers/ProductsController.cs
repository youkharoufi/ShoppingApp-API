﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("add-to-cart/{productId}/{userId}/{quantity}")]
        public async Task<ActionResult<Cart>> addToCart(int productId, string userId, int quantity)
        {
            var cart = await _context.Cart.Where(i=> i.UserId == userId).FirstOrDefaultAsync();

            var product = await _context.Products.Where(o => o.ProductId == productId).FirstOrDefaultAsync();

            if(product == null)
            {
                return NotFound("No such product in database");
            }

            if(cart == null)
            {
                return BadRequest("Create your cart first");
            }

            if(cart.CartItems == null)
            {
                cart.CartItems = new List<CartItems>();
            }

            var cartItem = new CartItems
            {
                UserId = userId,
                ItemName = product.ProductName,
                CartId = cart.CartId,
                Description = product.Description,
                ItemPhotoUrl = product.PhotoUrl1,
                ItemPrice = product.Price,
                ItemQuantity = quantity,
            };


                var cartIn = await _context.CartItems.Where(o => o.ItemName == product.ProductName).FirstOrDefaultAsync();
                if(cartIn != null)
                {
                    cartIn.ItemQuantity = cartIn.ItemQuantity + quantity;
                    await _context.SaveChangesAsync();
                    return Ok(cart);
                }

          

            cart.CartItems.Add(cartItem);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  // or log it using a logging framework
                throw;
            }

            return Ok(cart);
        }

        [HttpGet("filter-by-name/{name}")]
        public async Task<ActionResult<List<Product>>> filterProducts(string name)
        {
            if(name == "" || name == null) return await _context.Products.ToListAsync();

            var products = await _context.Products.Where(l => l.ProductName.Contains(name)).ToListAsync();

            return Ok(products);
        }



    }


}
