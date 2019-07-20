using System;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Services;

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
                
                var result = _productRepository.Select(id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            try
            {
                // _productService.Post<ProductValidator>(product);
                // return  Ok(product.Id);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                 _productRepository.Insert(product);
                return Ok(product.Id);
                
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