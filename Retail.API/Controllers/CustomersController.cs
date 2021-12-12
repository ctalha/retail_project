using Microsoft.AspNetCore.Mvc;
using Retail.Business.Interfaces;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Retail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var result = await _customerService.GetAllAsync();
            if (result.IsSuccessed)
            {
         
                return Ok(result);
            }
            return BadRequest(result);
        }

        
        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer(CreateCustomerDto createCustomerDto)
        {
            var result = await _customerService.AddAsync(createCustomerDto);
            if (result.IsSuccessed)
            {

                return Ok(result);

            }
            return BadRequest(result);
            
        }

        [HttpPost("update")]

        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var result = await _customerService.UpdateAsync(customer);
            if (result.IsSuccessed)
            {

                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("delete")]

        public async Task<IActionResult> DeleteCustomer(Customer customer)
        {
            var result = await _customerService.DeleteAsync(customer);
            if (result.IsSuccessed)
            {

                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("getbyid")]

        public async Task<IActionResult> GetByIdCustomer(int customerId)
        {
            var result = await _customerService.GetByIdAsync(customerId);
            if (result.IsSuccessed)
            {

                return Ok(result);

            }
            return BadRequest(result);

        }
    }
}
