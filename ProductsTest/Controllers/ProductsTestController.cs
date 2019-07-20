using Microsoft.AspNetCore.Mvc;
using Xunit;
using ProductsAPI.Controllers;
using ProductsAPI.Services;
using Microsoft.AspNetCore.Hosting;
using ProductsAPI.Models;

namespace ProductsTest.Controllers
{
    public class ProductsTestController
    {
        ProductsController _controller;
        IProductRepository _service;
        public ProductsTestController()
        {
             _service = new ProductRepository();
            _controller = new ProductsController(_service);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get(1);
        
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(999);
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Product product = new Product()
            {
                Name = "Guinness Original 6 Pack",
                Price = 12.00M
            };
        
            // Act
            var okResult = _controller.Post(product);
        
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            Product nameMissingItem = new Product()
            {
                Price = 12.00M
            };
            _controller.ModelState.AddModelError("Name", "Required");
        
            // Act
            var badResponse = _controller.Post(nameMissingItem);
        
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
    }
}