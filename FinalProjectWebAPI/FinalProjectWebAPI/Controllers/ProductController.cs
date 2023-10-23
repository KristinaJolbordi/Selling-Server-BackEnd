using FinalProjectWebAPI.DomainModels.Product;
using FinalProjectWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("AddProduct")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        try
        {
            var addedProduct = await _productService.AddProduct(product);
            return Ok(addedProduct);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }
    [HttpPost("arrange")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<WarehouseArrangementResult>> ArrangeProductInWarehouse(ProductArrangement arrangement)
    {
        try
        {
            var result = await _productService.ArrangeProductInWarehouse(arrangement);
            if (result.Equals(WarehouseArrangementResult.ProductOrSupplierNotFound))
            {
                return NotFound(new { message = "Product or Supplier not found" });
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }



    [HttpGet("GetProductInfoById")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<ProductInfo>> GetProductInfoById(int id)
    {
        try
        {
            var productInfo = await _productService.GetProductInfoById(id);
            if (productInfo == null)
                return NotFound();

            return Ok(productInfo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }

    [HttpPut("UpdateProduct")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
    {
        try
        {
            if (id != product.Id)
                return BadRequest(new { message = "Invalid request" });

            var updatedProduct = await _productService.UpdateProduct(product);
            return Ok(updatedProduct);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }

    [HttpDelete("DeleteProduct")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<bool>> DeleteProduct(int id)
    {
        try
        {
            var isDeleted = await _productService.DeleteProduct(id);
            if (!isDeleted)
                return NotFound(new { message = "Product not found" });

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }

    [HttpGet("GetAllProducts")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        try
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }

    [HttpGet("GetProductsExpiringIn14Days")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsExpiringIn14Days()
    {
        try
        {
            var expiringProducts = await _productService.GetProductsExpiringIn14Days();
            return Ok(expiringProducts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }

    [HttpPost("ApplyDiscountToProduct")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> ApplyDiscountToProduct(int productId, decimal discountAmount)
    {
        try
        {
            await _productService.ApplyDiscountToProduct(productId, discountAmount);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }

    [HttpPost("ExpireProducts")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<bool>> ExpireProducts()
    {
        try
        {
            var result = await _productService.ExpireProducts();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }
}
