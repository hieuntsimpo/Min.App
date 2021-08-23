
using Min.App.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Min.App.Repository.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product AddProduct(Product item);
    }
}
