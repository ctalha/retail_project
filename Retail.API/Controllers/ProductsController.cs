using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retail.Business.Interfaces;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService orderService)
        {
            _productService = orderService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllAsync();
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _productService.AddAsync(product);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = await _productService.UpdateAsync(product);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            var result = await _productService.DeleteAsync(product);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdProduct(int productId)
        {
            var result = await _productService.GetByIdAsync(productId);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductsbyorderid")]
        public async Task<IActionResult> GetProductsByOrderId(int orderId)
        {
            var result = await _productService.GetProductsByOrderId(orderId);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
