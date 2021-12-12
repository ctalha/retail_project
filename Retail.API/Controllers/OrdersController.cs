using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retail.Business.Interfaces;
using Retail.Core.Performance;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Retail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        private IOrderDetailService _orderDetailService;
        public OrdersController(IOrderService orderService,IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllOrders() 
        {
            var result = await _orderService.GetAllAsync();
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var result = await _orderService.AddAsync(order);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }
        [HttpPost("addDetail")]
        public async Task<IActionResult> AddDetailOrder(CreateOrderDto createOrderDto)
        {
            var result = await _orderDetailService.AddAsync(createOrderDto);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateOrder(Order order)
        {

            var result = await _orderService.UpdateAsync(order);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteOrder(Order order)
        {
            var result = await _orderService.DeleteAsync(order);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdOrder(int orderId)
        {
            var result = await _orderService.GetByIdAsync(orderId);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getorderdetaildtos")]
        public async Task<IActionResult> GetOrderDetailDtos(int orderId)
        {
            var result =  await _orderService.GetOrderDetailDtosById(orderId);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getorderlistresponsedtos")]
        public async Task<IActionResult> GetOrderListResponseDtos()
        {
            var result = await _orderService.GetOrderListResponseDtos();
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateordersituation")]
        public async Task<IActionResult> UpdateOrderSituation(UpdateOrderSituation updateOrderSituation)
        {
            var result = await _orderService.UpdateOrderSituation(updateOrderSituation);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
