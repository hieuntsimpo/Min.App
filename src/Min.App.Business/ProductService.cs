
using AutoMapper;
using Min.App.Biz.Dtos;
using Min.App.Common;
using Min.App.Core;
using Min.App.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Biz
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _producttRepository;
        private readonly IMapper _mapper;
        public ProductService(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _producttRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAllEntitiesAsync(ProductDto item)
        {
            LoggingService.LogAction("Staring logging");

            var productItem = _mapper.Map<Product>(item);

            var department = _producttRepository.AddProduct(productItem);

            //// Commit all changes with one single commit
            var saved = await _unitOfWork.CommitAsync();

            return saved > 0;
        }
    }
}
