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
using backend.Entity;
using backend.Repositories;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductService _productService;
        private readonly ICartRepository _productRepository;
        public ProductController(DBSHop context, IProductService productService, ICartRepository productRepository)
        {
            _productService = productService;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductFilter>>> GetProducts(int pageNumber = 1, int pageSize = 20, string? textSearch = "")
        {
            var res = await _productService.GetProducts(pageNumber, pageSize, textSearch);
            return Ok(res);
        }

        // GET: api/Product
        [HttpGet("GetProductByRange")]
        public async Task<ActionResult<ProductFilter>> GetProductByRange(int minRange,int maxRange, int pageNumber = 1, int pageSize = 20, string? textSearch = "")
        {
            var res = await _productService.GetProductByRange(minRange,maxRange,pageNumber,pageSize,textSearch);
            return Ok(res);
        }
        // GET: api/Product
        [HttpGet("GetProductByCategory")]
        public async Task<ActionResult<ProductFilter>> GetProductByCategory(int id,int pageNumber = 1, int pageSize = 20,string? textSearch = "")
        {
            var res = await _productService.GetProductByCategory(id,pageNumber,pageSize,textSearch);
            return Ok(res);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductView>> GetProductById(int id)
        {
            var res = await _productService.GetProductById(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        
        [HttpGet("GetProductByIdUser")]
        public async Task<ActionResult<List<CartProductView>>> GetProductByIdCart(int id)
        {
                var res =  _productRepository.GetProductsByUserId(id);
                return res;
        }
        [HttpGet("GetListProductNew")]
        public async Task<ActionResult<List<SanPham>>> GetListProductNew(int pageNumber = 1, int pageSize = 20, string? textSearch = "")
        {
            var res = await _productService.GetListProductNew(pageNumber,pageSize,textSearch);
            return Ok(res);
        }




    }
}
