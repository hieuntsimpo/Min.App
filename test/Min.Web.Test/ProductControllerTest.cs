using Microsoft.AspNetCore.Mvc;
using Min.App.Biz;
using Min.App.Biz.Dtos;
using Min.App.Web;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.Web.Test
{
    public class ProductControllerTest
    {
        private Mock<IProductService> _mockProductService;

        [SetUp]
        public void Setup()
        {

            _mockProductService = new Mock<IProductService>();

        }

        [Test]
        public async Task Can_Add_Product_Then_Return_OK()
        {

            var productService = new ProductController(_mockProductService.Object);

            // Act
            var result = await productService.AddProduct(new ProductDto());

            // Assert            
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
