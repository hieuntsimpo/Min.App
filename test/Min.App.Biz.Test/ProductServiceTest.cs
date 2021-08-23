using AutoMapper;
using Min.App.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Biz.Test
{
    public class ProductServiceTest
    {
        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
             
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockProductRepository = new Mock<IProductRepository>();
            
        }

        [Test]
        public async Task Valid_InsertDeviceIfNotFound()
        {
            
            var productService = new ProductService(_mockUnitOfWork.Object,_mockProductRepository.Object,_mockMapper.Object);
           
            // Act
            var result = await productService.AddAllEntitiesAsync(new Dtos.ProductDto());

            // Assert            
            Assert.AreEqual(true, result);
        }

    }
}
