using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retail.Business.Interfaces;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfterSalesController : ControllerBase
    {
        private IAfterSaleService _afterSaleService;

        public AfterSalesController(IAfterSaleService afterSaleService)
        {
            _afterSaleService = afterSaleService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAfterSales()
        {
            var result = await _afterSaleService.GetAllAsync();
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAfterSale(AfterSale afterSale)
        {
            var result = await _afterSaleService.AddAsync(afterSale);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAfterSale(AfterSale afterSale)
        {
            var result = await _afterSaleService.UpdateAsync(afterSale);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAfterSale(AfterSale afterSale)
        {
            var result = await _afterSaleService.DeleteAsync(afterSale);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAfterSale(int afterSaleId)
        {
            var result = await _afterSaleService.GetByIdAsync(afterSaleId);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getaftersalebyorderid")]
        public async Task<IActionResult> g(int id)
        {
            var result = await _afterSaleService.GetAfterSaleByOrderId(id);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
