using Microsoft.AspNetCore.Mvc;
using Product_Inventory_Management_API.Models;
using Product_Inventory_Management_API.Services;
using System;
using System.Collections.Generic;

namespace Product_Inventory_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching products: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                    return NotFound($"Product with ID {id} not found.");
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching product: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Product data is null.");

            try
            {
                _productService.CreateProduct(product);
                return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating product: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Product data is null.");

            try
            {
                _productService.UpdateProduct(id, product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating product: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting product: {ex.Message}");
            }
        }

        [HttpPost("insert")]
        public IActionResult InsertInitialData()
        {
            try
            {
                _productService.InsertInitialData();
                return Ok("Initial product data inserted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error inserting initial data: {ex.Message}");
            }
        }
    }
}
