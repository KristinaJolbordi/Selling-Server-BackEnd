using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectWebAPI.Model;
using FinalProjectWebAPI.BusinessLogic.Contracts;
using FinalProjectWebAPI.DomainModels.Customer;
using System.Net.Mime;


namespace FinalProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        [HttpGet("GetAllCustomers", Name = "GetAllCustomers")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDTO>))]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers() => _customerService.GetCustomers();

        // GET: api/Customers/5
        [HttpGet("GetCustomerById/{id:int}", Name = "GetCustomerById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDTO>))]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id) => _customerService.GetCustomerById(id);

        [HttpPost("CreateCustomer", Name = "CreateCustomer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                if (customer == null || !customer.Id.HasValue)
                    return BadRequest("მონაცემები არავალიდურია");
                var result = _customerService.RegisterCustomer(customer);
                if (!result)
                    throw new Exception("კლიენტის დარეგისტრირება არ მოხდა!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpPost("EditCustomer", Name = "EditCustomer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                if (customer == null || !customer.Id.HasValue)
                    return BadRequest("მონაცემები არავალიდურია");
                var c = _customerService.GetCustomerById(customer.Id.Value);
                if (c == null)
                    return NotFound($"მომხმარებელი უნიკალური იდენტიფიკატორით {customer.Id.Value} არ იძებნება");
                var result = _customerService.EditCustomer(c);
                if (!result)
                    throw new Exception("კლიენტის რედაქტირება არ მოხდა!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("DeleteCustomer/{id:int}", Name = "DeleteCustomerId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var c = _customerService.GetCustomerById(id);
                if (c == null)
                    return NotFound("მონაცემები არავალიდურია");
                var result = _customerService.DeleteCustomer(id);
                if (!result)
                    throw new Exception("კლიენტის წაშლა არ მოხდა!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
