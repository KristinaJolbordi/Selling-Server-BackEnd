using FinalProjectWebAPI.DomainModels.Sales;
using FinalProjectWebAPI.Model;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly ISalesService _salesService;

    public SalesController(ISalesService salesService)
    {
        _salesService = salesService;
    }

    [HttpPost("sell-product")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult SellProduct([FromBody] SellProductRequest request)
    {
        if (request == null)
            return BadRequest("Invalid request data.");
        var order = _salesService.SellProduct(request.CustomerId, request.ProductId, request.Quantity);
        if (order == null)
            return NotFound("Product or customer not found, or order creation failed.");
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    [HttpGet("get-product-info")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetProductInformation([FromQuery] string productCode)
    {
        if (string.IsNullOrWhiteSpace(productCode))
            return BadRequest("Product code is required.");
        var product = _salesService.GetProductInformation(productCode);
        if (product == null)
            return NotFound("Product not found.");
        return Ok(product);
    }

    [HttpGet("GetOrderById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetOrderById(int id)
    {
        var order = _salesService.GetOrderById(id);
        if (order == null)
            return NotFound("Order not found.");
        return Ok(order);
    }
}


