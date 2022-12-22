using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using backend.Services;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        
        [HttpPost("AddProductToCart")]
        public async Task<ActionResult> AddProductToCart(int idCustomer, int idProduct,int count = 1)
        {
            var res = await _cartService.AddProductToCart(idCustomer,idProduct,count);
            return StatusCode(200, res);
        }
        [HttpPost("CheckoutCart")]
        public async Task<ActionResult> Checkout(int userId)
        {
            var res = await _cartService.Checkout(userId);
            return StatusCode(200, res);
        }

        [HttpPut("EditProductToCart")]
        public async Task<ActionResult> EditProductToCart(ChiTietHoaDon item)
        {
            var res = await _cartService.EditProductToCart(item);
            return StatusCode(201, res);
        }

        [HttpDelete("DeleteProductToCart")]
        public async Task<ActionResult> DeleteProductToCart(int idUser,int idProduct)
        {
            var res = await _cartService.DeleteProductToCart(idUser,idProduct);
            if (res > 0)
            {
                return StatusCode(200, res);
            }
            return StatusCode(500,res);
            
        }
    }
}
