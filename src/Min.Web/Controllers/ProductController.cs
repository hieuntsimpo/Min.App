using Microsoft.AspNetCore.Mvc;
using Min.App.Biz;
using Min.App.Biz.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Min.App.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductDto item)
        {
            await _productService.AddAllEntitiesAsync(item);

            return Ok();
        }
    }
}
