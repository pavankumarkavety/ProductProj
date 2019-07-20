using System;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Application.Models;
using ProductsAPI.Application.Services;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET api/products/1
         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                
                Product product = _productRepository.Select(id);
                if (product == null)
                {
                    return NotFound("Product does not exist");
                }
                return Ok(product);
            }
            catch(Exception e)
            {
                return BadRequest("Error while retrieving product: " + e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            try
            {
                // _productService.Post<ProductValidator>(product);
                // return  Ok(product.Id);
                 _productRepository.Insert(product);
                return Ok("sdf");
                
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/values
        // [HttpPost]
        // public void Post([FromBody]Product value)
        // {
        // }

    }
}